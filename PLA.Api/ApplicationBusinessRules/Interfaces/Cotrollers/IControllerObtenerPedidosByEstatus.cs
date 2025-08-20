namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedidosByEstatus
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoByDay>> respuesta)> ObtenerPedidosByEstatus(bool estatus, int idUsuario);
}
