namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerActualizarPedido : IControllerActualizarPedido
{
    private readonly IActualizarPedidoInputPort _inputPort;

    public ControllerActualizarPedido(IActualizarPedidoInputPort inputPort) =>
        _inputPort = inputPort;
    

    public async ValueTask<(int statusCode, string mensaje)> ActualizarPedido(PedidoDTO pedido, int idUsuario)
    {
        try
        {
            (bool estatusOperacion, string mensaje) = await _inputPort.Handler(pedido, idUsuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, mensaje);
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, "Error en el servidor");
        }        
    }
}
