namespace PLA.Api.UI.Endpoints;

internal static class PedidosEndpoints
{
    private const string NAME_CLAIM_ID = "userId";

    internal static WebApplication UsePedidosEndpoints(this WebApplication app)
    {
        RouteGroupBuilder Group = app.MapGroup("Api/Pedidos").RequireAuthorization();

        Group.MapPost("Pedido", async (IControllerRegistrarPedido controller, ClaimsPrincipal claims, PedidoDTO pedido) =>
        {
            
            var (statusCode, mensaje) = await controller.RegistrarPedido(pedido, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(mensaje) : Results.Ok(mensaje);
        });

        Group.MapPut("Pedido", async (IControllerActualizarPedido controller, ClaimsPrincipal claims, PedidoDTO pedido) =>
        {
            var (statusCode, mensaje) = await controller.ActualizarPedido(pedido, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(mensaje) : Results.Ok(mensaje);
        });

        Group.MapGet("Pedido", async (IControllerObtenerPedido controller, ClaimsPrincipal claims, long id) =>
        {
            var (statusCode, pedido) = await controller.ObtenerPedido(id, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(pedido) : Results.Ok(pedido);
        });

        Group.MapGet("Pedidos/", async (IControllerObtenerPedidos controller, ClaimsPrincipal claims, 
            DateTime dateTimeStart, DateTime dateTimeEnd) =>
        {
            var (statusCode, pedidos) = await controller.ObtenerPedidos(dateTimeStart, dateTimeEnd, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(pedidos) : Results.Ok(pedidos);
        });

        Group.MapGet("PedidosFiltro/", async (IControllerObtenerPedidosFiltrados controller, ClaimsPrincipal claims, string filtro) =>
        {
            var (statusCode, pedidos) = await controller.ObtenerPedidosFiltrados(filtro, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(pedidos) : Results.Ok(pedidos);
        });
        return app;
    }    
}
