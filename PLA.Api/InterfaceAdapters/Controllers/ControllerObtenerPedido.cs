namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedido : IControllerObtenerPedido
{

    private readonly IObtenerPedidoInputPort _inputPort;

    public ControllerObtenerPedido(IObtenerPedidoInputPort inputPort) =>
    _inputPort = inputPort;

    public async ValueTask<(int statusCode, PedidoDTO pedido)> ObtenerPedido(long idPedido, int idUsuario)
    {
        try
        {
            var pedido = await _inputPort.Handler(idPedido, idUsuario);
            return (pedido.IsNull() ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, pedido);
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, null);
        }
    }
}
