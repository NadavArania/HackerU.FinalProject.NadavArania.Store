using HackerU.FinalProject.NadavArania.Store.Api_And_UI.Controllers;
using HackerU.FinalProject.NadavArania.Store.Core.Converter;
using HackerU.FinalProject.NadavArania.Store.Core.Repositories;
using HackerU.FinalProject.NadavArania.Store.Core.Services;
using HackerU.FinalProject.NadavArania.Store.Db.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreContext>();
builder.Services.AddAutoMapper(typeof(AMConverter));
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
builder.Services.AddTransient(typeof(IProductService), typeof(ProductService));
builder.Services.AddTransient(typeof(IOrderService), typeof(OrderService));
builder.Services.AddTransient(typeof(IOrderProductService), typeof(OrderProductService));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAuthentication(UsersController.authSchema).AddCookie(UsersController.authSchema);
builder.Services.AddAuthorization();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession((e) =>
{
    e.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
