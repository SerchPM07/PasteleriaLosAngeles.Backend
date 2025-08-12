namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerActualizarPedido
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<string> respuesta)> ActualizarPedido(PedidoDTO pedido, int idUsuario);
}
