using ProjetoNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Connections;
using ProjetoNet.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbConexaoFactory>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
// Configuração de serviços
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

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


app.UseCors("CorsPolicy");
// Configuração dos middlewares antes de rodar o app
app.UseDefaultFiles(new DefaultFilesOptions());
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();
