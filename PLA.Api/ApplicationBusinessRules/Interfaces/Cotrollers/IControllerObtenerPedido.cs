namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedido
{
    ValueTask<(int statusCode, PedidoDTO pedido)> ObtenerPedido(long idPedido, int idUsuario);
}
