namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedidos
{
    ValueTask<(int statusCode, List<PedidoDTO> pedidios)> ObtenerPedidos(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario);
}
