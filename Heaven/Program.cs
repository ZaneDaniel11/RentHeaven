using Microsoft.EntityFrameworkCore;
using Heaven.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ ALL service registrations must go here:
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RentContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
           .LogTo(Console.WriteLine, LogLevel.Information));

// ✅ Once app is built, no more services can be added.
var app = builder.Build();

// ✅ Now configure the request pipeline:
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ✅ Add endpoint routing AFTER the pipeline setup
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
