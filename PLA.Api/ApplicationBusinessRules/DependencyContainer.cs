namespace PLA.Api.ApplicationBusinessRules;

public static class DependencyContainer
{
    internal static IServiceCollection AddUseCasePLA(this IServiceCollection services)
    {
        services.AddScoped<IActualizarPedidoInputPort, ActualizarPedidoHandler>();
        services.AddScoped<IObtenerPedidoInputPort, ObtenerPedidoHandler>();
        services.AddScoped<IObtenerPedidosInputPort, ObtenerPedidosHandler>();
        services.AddScoped<IObtenerPedidosFiltradosInputPort, ObtenerPedidosFiltradosHandler>();
        services.AddScoped<IRegistrarPedidoInputPort, RegistrarPedidoHandler>();
        services.AddScoped<IActualizarUsuarioInputPort, ActualizarUsuarioHandler>();
        services.AddScoped<IActualizarPasswordInputPort, ActualizarPasswordHandler>();
        services.AddScoped<ILoginUsuarioInputPort, LoginUsuarioHandler>();
        services.AddScoped<IObtenerUsuarioInputPort, ObtenerUsuarioHandler>();
        services.AddScoped<IRegistrarUsuarioInputPort, RegistrarUsuarioHandler>();
        services.AddScoped<IAutoLoginInputPort, AutoLoginHandler>();
        return services;
    }
}

