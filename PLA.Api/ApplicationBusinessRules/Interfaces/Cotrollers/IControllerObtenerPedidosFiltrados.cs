namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedidosFiltrados
{
    ValueTask<(int statusCode, List<PedidoDTO> pedidos)> ObtenerPedidosFiltrados(string filtrado, int idUsuario);
}
