using Microsoft.EntityFrameworkCore;
using LojaWebCSharp.Data;
using LojaWebCSharp.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var culture = new List<CultureInfo> {
        new CultureInfo("pt"),
        new CultureInfo("en")
    };
    options.DefaultRequestCulture = new RequestCulture("pt");
    options.SupportedCultures = culture;
    options.SupportedUICultures = culture;
});


/*  
var ptBR = new CultureInfo("pt-BR");
var localizationOptions = RequestLocalizationOptions {
    DefaultRequestCulture = new RequestCulture(ptBR),
    SupportedCultures = new List<CultureInfo> { ptBR },
    SupportedUiCultures = new List<CultureInfo> { ptBR }
    };
*/

builder.Services.AddDbContext<LojaWebCSharpContext>(options =>{
    var connectionString = builder.Configuration.GetConnectionString("LojaWebCSharpContext");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<VendedorService>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<PedidoService>();

//builder.Services.AddDbContext<LojaWebCSharpContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("LojaWebCSharpContext") ?? throw new InvalidOperationException("Connection string 'LojaWebCSharpContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope()) {
    var services = serviceScope.ServiceProvider;
  
    var myDependency = services.GetRequiredService<SeedingService>();
    myDependency.Seed();
}

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
