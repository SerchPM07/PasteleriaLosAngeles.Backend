namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerRegistrarPedido
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<string> respuesta)> RegistrarPedido(PedidoDTO pedido, int idUsuario);
}
