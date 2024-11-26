namespace PLA.Api.UI.Endpoints;

internal static class PedidosEndpoints
{
    internal static WebApplication UsePedidosEndpoints(this WebApplication app)
    {
        RouteGroupBuilder Group = app.MapGroup("Pedidos").RequireAuthorization();
        return app;
    }
}
