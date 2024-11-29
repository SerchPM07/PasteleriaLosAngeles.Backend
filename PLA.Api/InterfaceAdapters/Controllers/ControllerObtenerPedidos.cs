using PLA.Api.Entities.POCO;

namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidos : IControllerObtenerPedidos
{
    private readonly IObtenerPedidosInputPort _inputPort;

    public ControllerObtenerPedidos(IObtenerPedidosInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, List<PedidoDTO> pedidios)> ObtenerPedidos(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario)
    {
        try
        {
            var pedido = await _inputPort.Handler(dateTimeStart, dateTimeEnd, idUsuario);
            return (pedido.IsNullOrEmpty() ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, pedido);
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, null);
        }
    }
}
