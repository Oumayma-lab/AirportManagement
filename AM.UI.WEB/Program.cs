using AM.Applactioncore.Intterfaces;
using AM.Applactioncore.Services;
using AM.ApplicationCore.Interfaces;
using AM.Infrastructeur;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DbContext, AMContext>(); //notre context 
//
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //
builder.Services.AddScoped<IServiceFlight, ServiceFlight>();
builder.Services.AddScoped<IServicePlane, ServicePlane>();
//coupler chaque respo avec un service
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));



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
