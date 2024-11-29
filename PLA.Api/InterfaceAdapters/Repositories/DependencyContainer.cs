namespace PLA.Api.InterfaceAdapters.Repositories;

public static class DependencyContainer
{
    public static IServiceCollection AddRepocitoryPLA(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddDbContext<PasteleriaDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(connectionString), options =>
            {
                options.UseNetTopologySuite();
            });
        });
        services.AddScoped<IActividadesRepocitory, ActividadesRepocitory>();
        services.AddScoped<IPedidosRepocitory, PedidosRepocitory>();
        services.AddScoped<IUsuariosRepocitory, UsuariosRepocitory>();
        return services;
    }
}

