namespace PLA.Api.InterfaceAdapters.Repositories;

public static class DependencyContainer
{
    public static IServiceCollection AddPLARepocitory(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddDbContext<PasteleriaDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(connectionString), options =>
            {
                options.UseNetTopologySuite();
            });
        });
        return services;
    }
}

