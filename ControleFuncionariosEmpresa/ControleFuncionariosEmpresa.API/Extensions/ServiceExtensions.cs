namespace ControleFuncionariosEmpresa.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurarCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }

    public static void ConfigurarIntegracaoIIS(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {
        });
    }
}