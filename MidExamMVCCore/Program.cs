using Microsoft.EntityFrameworkCore;
using MidExamMVCCore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CoreDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("StudentCon")));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(name: "Default", pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
