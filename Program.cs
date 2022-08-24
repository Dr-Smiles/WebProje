using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProje.Data;
using WebProje.Areas.Identity.Data;
using WebProje.Models;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDbContext<ProductContext>(opt =>
    opt.UseNpgsql(connectionString)
);
builder.Services.AddDbContext<Identity>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
    options.Password.RequiredUniqueChars = 0;})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


// builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//     .AddEntityFrameworkStores<ApplicationDbContext>()
//     .AddDefaultUI()
//     .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(10);
    options.Cookie.IsEssential = true;
});
builder.Services.AddMemoryCache();
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
 
    var cultures = new CultureInfo[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
    };
 
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
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


app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
	
app.UseRequestLocalization();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

//TODO Change cart system
//TODO Add Admin Panel
//TODO Add Login System
//TODO Add Register System
