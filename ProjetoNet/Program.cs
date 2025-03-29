using Microsoft.AspNetCore.Connections;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de servi�os
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o dos middlewares antes de rodar o app
app.UseDefaultFiles(new DefaultFilesOptions());
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();
