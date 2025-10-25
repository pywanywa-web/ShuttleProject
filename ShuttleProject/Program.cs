using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleProject.Filter;
using ShuttleProject.Models;
using ShuttleProject.Models.Data;
using ShuttleProject.Models.Data.MonitoringSystem;


var modelBuilder = WebApplication.CreateBuilder(args);


modelBuilder.Services.AddDbContext<MonitoringSystemContext>(options =>
options.UseSqlServer(modelBuilder.Configuration.GetConnectionString
("AppConnection")));
modelBuilder.Services.AddControllersWithViews();
modelBuilder.Services.AddScoped<ApiKeyAuthorizationFilter>();


modelBuilder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MonitoringSystemContext>();
modelBuilder.Services.AddRazorPages();

modelBuilder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

modelBuilder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});



var app = modelBuilder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}")
    .WithStaticAssets();


app.Run();
