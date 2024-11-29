namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerRegistrarPedido : IControllerRegistrarPedido
{
    private readonly IRegistrarPedidoInputPort _inputPort;
    public ControllerRegistrarPedido(IRegistrarPedidoInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, string mensaje)> RegistrarPedido(PedidoDTO pedido, int idUsuario)
    {
		try
		{
            var (estatusOperacion, mensaje) = await _inputPort.Handler(pedido, idUsuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, mensaje);
		}
		catch (Exception)
		{
			return (StatusCodes.Status500InternalServerError, "Ocurrrio un error en el servidor");
		}
    }
}

