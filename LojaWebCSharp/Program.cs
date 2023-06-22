using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LojaWebCSharp.Data;
using Microsoft.Extensions.Options;
using ServiceStack.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LojaWebCSharpContext>(options =>{
    var connectionString = builder.Configuration.GetConnectionString("LojaWebCSharpContext");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//builder.Services.AddDbContext<LojaWebCSharpContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("LojaWebCSharpContext") ?? throw new InvalidOperationException("Connection string 'LojaWebCSharpContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
