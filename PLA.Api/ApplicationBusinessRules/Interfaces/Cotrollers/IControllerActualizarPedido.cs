namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerActualizarPedido
{
    ValueTask<(int statusCode, string mensaje)> ActualizarPedido(PedidoDTO pedido, int idUsuario);
}
