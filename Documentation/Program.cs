using Microsoft.EntityFrameworkCore;
using Documentation.Service.Core;
using Documentation.Service.Veritabani;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<DokumanService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<UserService>();


var app = builder.Build();
app.UseSession();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
