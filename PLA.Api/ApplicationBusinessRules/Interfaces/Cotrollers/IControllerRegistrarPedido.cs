namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerRegistrarPedido
{
    ValueTask<(int statusCode, string mensaje)> RegistrarPedido(PedidoDTO pedido, int idUsuario);
}
