namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedido : IControllerObtenerPedido
{

    private readonly IObtenerPedidoInputPort _inputPort;

    public ControllerObtenerPedido(IObtenerPedidoInputPort inputPort) =>
    _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<PedidoDTO> respuesta)> ObtenerPedido(long idPedido, int idUsuario)
    {
        try
        {
            var pedido = await _inputPort.Handler(idPedido, idUsuario);
            return (pedido.IsNull() ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, new RespuestaGenericaDTO<PedidoDTO>
            {
                Mensaje = string.Empty,
                Objeto = pedido,
                EstatusOperacion = true
            });
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, new RespuestaGenericaDTO<PedidoDTO>
            {
                Mensaje = "Ocurrio un error en el servidor",
                Objeto = null,
                EstatusOperacion = false
            });
        }
    }
}
