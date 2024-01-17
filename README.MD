Curso Udemy: C# COMPLETO POO + Projetos
Projeto Final "Sistema WEB com ASP.NET Core MVC e Entity Framework" com professor Nelio Alves. 

Reescrevendo o projeto do curso com as versões atualizadas das ferramentas utilizadas.
1º Semestre de 2023 
* Visual Studio 2022
* .NET 6.0
* Entity Framework 7.0
* MySQL (Pomelo.EntityFrameworkCore.MySql - 7.0)

Alterações:
Ep. "Adaptação para MySQL e primeira migration", adaptação para uso com arquivo "Program.cs"

    builder.Services.AddDbContext<LojaWebCSharpContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("LojaWebCSharpContext");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

Ep. "Seeding Service", para iniciar o serviço na execução, adaptação para uso com arquivo "Program.cs"

    builder.Services.AddScoped<SeedingService>();

    using (var serviceScope = app.Services.CreateScope()) 
    {
        var services = serviceScope.ServiceProvider;
    
        var myDependency = services.GetRequiredService<SeedingService>();
        myDependency.Seed();
    }

Declaração do serviço, adaptação para uso com arquivo "Program.cs"

    builder.Services.AddScoped<VendedorService>();
    builder.Services.AddScoped<DepartamentoService>();

Ep. "App locale, number and date formatting" declarando o local com "Program.cs"

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

