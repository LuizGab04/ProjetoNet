using Microsoft.AspNetCore.Connections;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração dos middlewares antes de rodar o app
app.UseDefaultFiles(new DefaultFilesOptions());
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();
