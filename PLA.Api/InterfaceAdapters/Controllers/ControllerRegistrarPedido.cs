namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerRegistrarPedido : IControllerRegistrarPedido
{
    private readonly IRegistrarPedidoInputPort _inputPort;
    public ControllerRegistrarPedido(IRegistrarPedidoInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<string> respuesta)> RegistrarPedido(PedidoDTO pedido, int idUsuario)
    {
		try
		{
            var (estatusOperacion, mensaje) = await _inputPort.Handler(pedido, idUsuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, new RespuestaGenericaDTO<string>
            {
                Mensaje = string.Empty,
                Objeto = mensaje,
                EstatusOperacion = estatusOperacion
            });
		}
		catch (Exception)
		{
			return (StatusCodes.Status500InternalServerError, new RespuestaGenericaDTO<string>
            {
                Mensaje = "Ocurrrio un error en el servidor",
                Objeto = null,
                EstatusOperacion = false
            });
		}
    }
}

