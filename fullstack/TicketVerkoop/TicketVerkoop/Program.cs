using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using TicketModels.Data;
using TicketModels.Entities;
using TicketRepositories;
using TicketRepositories.interfaces;
using TicketService;
using TicketService.interfaces;
using TicketVerkoop.Data;
using TicketVerkoop.Util.Mail;
using TicketVerkoop.Util.PDF;
using TicketVerkoop.Util.PDF.Interface;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews()
    .AddViewLocalization
    (LanguageViewLocationExpanderFormat.SubFolder) // vertaling op View
    .AddDataAnnotationsLocalization(); // vertaling op ViewModel
// in welke map zitten de resources
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var supportedCultures = new[] { "nl", "en", "fr" };

builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.SetDefaultCulture(supportedCultures[0])
      .AddSupportedCultures(supportedCultures)  //Culture is used when formatting or parsing culture dependent data like dates, numbers, currencies, etc
      .AddSupportedUICultures(supportedCultures);  //UICulture is used when localizing strings, for example when using resource files.
});

//email toevoegen
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings")); 

//automapper toevoegen
builder.Services.AddAutoMapper(typeof(Program));

//dependency injection
builder.Services.AddTransient<TicketVerkoopDbContext, TicketVerkoopDbContext>();

builder.Services.AddTransient<IService<Match>, MatchService>();
builder.Services.AddTransient<IDAO<Match>, MatchDAO>();

builder.Services.AddTransient<VakIService<Vak>, VakService>();
builder.Services.AddTransient<VakIDAO<Vak>, VakDAO>();

builder.Services.AddTransient<ReserveringIService<Reservering>, ReserveringService>();
builder.Services.AddTransient<ReserveringIDAO<Reservering>, ReserveringDAO>();

builder.Services.AddTransient<UserIService<AspNetUser>, UserService>();
builder.Services.AddTransient<UserIDAO<AspNetUser>, UserDAO>();

builder.Services.AddTransient<SeizoenIService<Seizoen>, SeizoenService>();
builder.Services.AddTransient<SeizoenIDAO<Seizoen>, SeizoenDAO>();

builder.Services.AddTransient<IEmailSend, EmailSend>();
builder.Services.AddTransient<IReportService, ReportService>();

builder.Services.AddSingleton(typeof(IConverter),
    new SynchronizedConverter(new PdfTools()));

//sessie toevoegen
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "be.VIVES.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

//session
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
