namespace PLA.Api.UI.Endpoints;

internal static class PedidosEndpoints
{
    private const string NAME_CLAIM_ID = "userId";

    internal static WebApplication UsePedidosEndpoints(this WebApplication app)
    {
        RouteGroupBuilder Group = app.MapGroup("Api/Pedidos");

        Group.MapPost("Pedido", async (IControllerRegistrarPedido controller, ClaimsPrincipal claims, PedidoDTO pedido) =>
        {            
            var (statusCode, respuesta) = await controller.RegistrarPedido(pedido, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });

        Group.MapPut("Pedido", async (IControllerActualizarPedido controller, ClaimsPrincipal claims, PedidoDTO pedido) =>
        {
            var (statusCode, respuesta) = await controller.ActualizarPedido(pedido, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });

        Group.MapGet("Pedido", async (IControllerObtenerPedido controller, ClaimsPrincipal claims, long id) =>
        {
            var (statusCode, respuesta) = await controller.ObtenerPedido(id, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });

        Group.MapGet("Pedidos/", async (IControllerObtenerPedidos controller, ClaimsPrincipal claims, 
            DateTime dateTimeStart, DateTime dateTimeEnd) =>
        {
            var (statusCode, respuesta) = await controller.ObtenerPedidos(dateTimeStart, dateTimeEnd, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });

        Group.MapGet("PedidosFiltro/", async (IControllerObtenerPedidosFiltrados controller, ClaimsPrincipal claims, string filtro, bool estatus) =>
        {
            var (statusCode, respuesta) = await controller.ObtenerPedidosFiltrados(filtro, estatus, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });

        Group.MapGet("PedidosByEstatus/", async (IControllerObtenerPedidosByEstatus controller, ClaimsPrincipal claims, bool estatus) =>
        {
            var (statusCode, respuesta) = await controller.ObtenerPedidosByEstatus(estatus, claims.GetValueClaim(NAME_CLAIM_ID));
            return statusCode != StatusCodes.Status200OK ? Results.BadRequest(respuesta) : Results.Ok(respuesta);
        });
        return app;
    }    
}
