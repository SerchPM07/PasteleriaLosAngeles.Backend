namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedidos
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoDTO>> respuesta)> ObtenerPedidos(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario);
}
