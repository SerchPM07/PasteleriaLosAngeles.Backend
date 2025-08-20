namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedidosFiltrados
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoByDay>> respuesta)> ObtenerPedidosFiltrados(string filtrado, bool estatus, int idUsuario);
}
