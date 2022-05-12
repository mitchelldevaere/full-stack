using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketModels.Data;
using TicketModels.Entities;
using TicketRepositories;
using TicketRepositories.interfaces;
using TicketService;
using TicketService.interfaces;
using TicketVerkoop.Data;
using TicketVerkoop.Util.Mail;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//automapper toevoegen
builder.Services.AddAutoMapper(typeof(Program));

//dependency injection
builder.Services.AddTransient<TicketVerkoopDbContext, TicketVerkoopDbContext>();
// syntax services.AddTransient<service, implType>();
builder.Services.AddTransient<IService<Match>, MatchService>();
builder.Services.AddTransient<IDAO<Match>, MatchDAO>();

builder.Services.AddTransient<VakIService<Vak>, VakService>();
builder.Services.AddTransient<VakIDAO<Vak>, VakDAO>();

builder.Services.AddTransient<ReserveringIService<Reservering>, ReserveringService>();
builder.Services.AddTransient<ReserveringIDAO<Reservering>, ReserveringDAO>();

builder.Services.AddTransient<IEmailSend, EmailSend>();

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
