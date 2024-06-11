using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Entity;
using ServiceComputer.Model.DataModel;
using ServiceComputer.Reponsive.Base;
using ServiceComputer.Reponsive.IRepo;
using ServiceComputer.Reponsive.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBServiceComputerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register service
//builder.Services.AddScoped<IProductRepo, ProductRepo>();
//builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();

builder.Services.AddScoped<IReponsive<Product>, Reponsive<Product>>();
builder.Services.AddScoped<IReponsive<Category>, Reponsive<Category>>();
builder.Services.AddScoped<IShopCartRepo, ShopCartRepo>();
builder.Services.AddScoped<IReponsive<User>, Reponsive<User>>();
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

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Category}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomePage}/{action=Index}/{id?}");

var initData = new InitDataInfo(app.Services);
initData.Seed();
app.Run();