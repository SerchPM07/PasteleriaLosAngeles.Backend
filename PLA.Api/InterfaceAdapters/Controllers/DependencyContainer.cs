namespace PLA.Api.InterfaceAdapters.Controllers;

public static class DependencyContainer
{
    public static IServiceCollection AddControllersPLA(this IServiceCollection services)
    {
        services.AddScoped<IControllerActualizarPedido, ControllerActualizarPedido>();
        services.AddScoped<IControllerActualizarUsuario, ControllerActualizarUsuario>();
        services.AddScoped<IControllerActualizarPassword, ControllerActualizarPassword>();
        services.AddScoped<IControllerLoginUsuario, ControllerLoginUsuario>();
        services.AddScoped<IControllerObtenerPedido, ControllerObtenerPedido>();
        services.AddScoped<IControllerObtenerPedidos, ControllerObtenerPedidos>();
        services.AddScoped<IControllerObtenerPedidosFiltrados, ControllerObtenerPedidosFiltrados>();
        services.AddScoped<IControllerObtenerUsuario, ControllerObtenerUsuario>();
        services.AddScoped<IControllerRegistrarPedido, ControllerRegistrarPedido>();
        services.AddScoped<IControllerRegistrarUsuario, ControllerRegistrarUsuario>();
        services.AddScoped<IControllerAutoLogin, ControllerAutoLogin>();
        return services;
    }
}

