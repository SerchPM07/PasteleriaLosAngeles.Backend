using PLA.Api.Entities.POCO;

namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidos : IControllerObtenerPedidos
{
    private readonly IObtenerPedidosInputPort _inputPort;

    public ControllerObtenerPedidos(IObtenerPedidosInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoDTO>> respuesta)> ObtenerPedidos(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario)
    {
        try
        {
            var pedidos = await _inputPort.Handler(dateTimeStart, dateTimeEnd, idUsuario);
            return (pedidos.IsNullOrEmpty() ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, new RespuestaGenericaDTO<List<PedidoDTO>>
            {
                Mensaje = string.Empty,
                Objeto = pedidos,
                EstatusOperacion = true
            });
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, new RespuestaGenericaDTO<List<PedidoDTO>>
            {
                Mensaje = "Ocurrio un error en el servidor",
                Objeto = null,
                EstatusOperacion = false
            });
        }
    }
}
