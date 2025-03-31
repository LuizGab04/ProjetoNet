using Microsoft.AspNetCore.Connections;
using ProjetoNet.Repositories;
using ProjetoNet.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbConexaoFactory>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
// Configura��o de servi�os
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/login.html");
        return;
    }
    await next();
});

app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
var defaltFilesOption =
// Configura��o dos middlewares antes de rodar o app
app.UseDefaultFiles(new DefaultFilesOptions());
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();
