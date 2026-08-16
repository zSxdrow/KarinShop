using KarinShop.Application.Interfaces.Context;
using KarinShop.Application.Interfaces.FacadPatterns;
using KarinShop.Application.Interfaces.FacadPatterns.HomePage;
using KarinShop.Application.Interfaces.FacadPatterns.User;
using KarinShop.Application.Services.Common.GetCategory;
using KarinShop.Application.Services.Common.GetMenu;
using KarinShop.Application.Services.HomePage.Facade;
using KarinShop.Application.Services.Products.Commands.AddProductImage;
using KarinShop.Application.Services.Products.FacadPattern;
using KarinShop.Application.Services.Products.Queries.GetChildCategories;
using KarinShop.Application.Services.Users.Commands.UserLogin;
using KarinShop.Application.Services.Users.Facade;
using KarinShop.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//-----------------User , Context , product , HomePage

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IProductFacad, ProductFacade>();
builder.Services.AddScoped<IUserLogin, UserLoginServices>();
builder.Services.AddScoped<IHomePageFacade, HomePageFacadeservices>();



//---------------Common
builder.Services.AddScoped<IGetMenuItem, GetMenuItemServices>();
builder.Services.AddScoped<IGetChildCategories, GetChildCategoriesServices>();
builder.Services.AddScoped<IGetCategory, GetCategoryServices>();
builder.Services.AddScoped<IAddProductImage , AddProductImageServices>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
