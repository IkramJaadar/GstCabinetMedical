using GstCabinetMedicals;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

	// Autres services...

	builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		.AddCookie(options =>
		{
			options.Cookie.Name = "YourAuthCookieName";
			options.Cookie.HttpOnly = true;
			options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Durée de validité de l'authentification (ici, 30 minutes).
			options.LoginPath = "/Doctor/Login"; // Chemin de la page de connexion.
			options.LogoutPath = "/Doctor/Logout"; // Chemin de la page de déconnexion.
			options.AccessDeniedPath = "/Error/AccessDenied"; // Chemin de la page d'accès refusé.
		});

// Autres services...
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options=>
{
    options.IdleTimeout = TimeSpan.FromMinutes (10);
});
object value = builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AutheMed}/{action=Login}/{id?}");

app.Run();
