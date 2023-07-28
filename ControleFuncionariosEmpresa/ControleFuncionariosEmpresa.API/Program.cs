using ControleFuncionariosEmpresa.API.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args); // Cria o builder da aplicaçãox

builder.Services.AddControllers(); // Adiciona o uso de controllers

builder.Services.ConfigurarCors();
builder.Services.ConfigurarIntegracaoIIS();

var app = builder.Build(); // Cria a aplicação

if (app.Environment.IsDevelopment()) // Verifica se o ambiente é de desenvolvimento
{
    app.UseDeveloperExceptionPage(); // Habilita o uso de página de erro
}
else
{
    app.UseHsts(); // Habilita o uso de HSTS
}

app.UseHttpsRedirection(); // Redireciona para HTTPS
app.UseStaticFiles(); // Habilita o uso de arquivos estáticos
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    // Habilita o uso de proxy reverso
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy"); // Habilita o CORS
app.UseAuthorization(); // Habilita o uso de autorização
app.MapControllers(); // Habilita o uso de controllers
app.Run(); // Executa a aplicação