Curso Udemy: C# COMPLETO POO + Projetos
Projeto Final "Sistema WEB com ASP.NET Core MVC e Entity Framework" com professor Nelio Alves. 

Reescrevendo o projeto do curso com as versões atualizadas das ferramentas utilizadas.
1º Semestre de 2023 
* Visual Studio 2022
* .NET 6.0
* Entity Framework 7.0
* MySQL (Pomelo.EntityFrameworkCore.MySql - 7.0)


1ª Alteração:
builder.Services.AddDbContext<LojaWebCSharpContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("LojaWebCSharpContext");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

*** MUDANDO O TEMA BOOTSTRAP
https://github.com/brunoness/LojaWebCSharpMVC.git