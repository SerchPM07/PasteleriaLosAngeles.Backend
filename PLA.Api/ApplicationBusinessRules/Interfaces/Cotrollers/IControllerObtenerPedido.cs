namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerPedido
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<PedidoDTO> respuesta)> ObtenerPedido(long idPedido, int idUsuario);
}
