namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidosFiltrados : IControllerObtenerPedidosFiltrados
{
    private readonly IObtenerPedidosFiltradosInputPort _inputPort;
    public ControllerObtenerPedidosFiltrados(IObtenerPedidosFiltradosInputPort inputPort) =>
        _inputPort = inputPort;    

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoDTO>> respuesta)> ObtenerPedidosFiltrados(string filtrado, int idUsuario)
    {
		try
		{
            var pedidos = await _inputPort.Handler(filtrado, idUsuario);
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
