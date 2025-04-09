using Facebook.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register FacebookContext
builder.Services.AddDbContext<FacebookContext>(options =>
    options.UseSqlite("Data Source=facebook.db"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // Enables serving from wwwroot

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection(); // ✅ Only redirect in production
}

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
