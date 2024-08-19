using Microsoft.EntityFrameworkCore;
using ProductCrudDb.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ProductMgmtMvcAppDbContext>(options =>
//options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
//);

builder.Services.AddDbContext<ProductMgmtMvcAppDbContext>(
    options =>
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

