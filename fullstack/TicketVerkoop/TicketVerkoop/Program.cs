using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketModels.Data;
using TicketModels.Entities;
using TicketRepositories;
using TicketRepositories.interfaces;
using TicketService;
using TicketService.interfaces;
using TicketVerkoop.Data;

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
