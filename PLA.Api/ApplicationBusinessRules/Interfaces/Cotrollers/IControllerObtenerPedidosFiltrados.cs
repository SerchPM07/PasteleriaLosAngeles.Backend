namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedidosFiltrados
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoDTO>> respuesta)> ObtenerPedidosFiltrados(string filtrado, int idUsuario);
}
