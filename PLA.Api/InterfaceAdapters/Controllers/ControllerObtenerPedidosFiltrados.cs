namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidosFiltrados : IControllerObtenerPedidosFiltrados
{
    private readonly IObtenerPedidosFiltradosInputPort _inputPort;
    public ControllerObtenerPedidosFiltrados(IObtenerPedidosFiltradosInputPort inputPort) =>
    _inputPort = inputPort;    

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoByDay>> respuesta)> ObtenerPedidosFiltrados(string filtrado, bool estatus, int idUsuario)
    {
		try
		{
            var pedidosByDay = await _inputPort.Handler(filtrado, estatus, idUsuario);
            return (pedidosByDay.IsNullOrEmpty() ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, new RespuestaGenericaDTO<List<PedidoByDay>>
            {
                Mensaje = string.Empty,
                Objeto = pedidosByDay,
                EstatusOperacion = true
            });
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, new RespuestaGenericaDTO<List<PedidoByDay>>
            {
                Mensaje = "Ocurrio un error en el servidor",
                Objeto = null,
                EstatusOperacion = false
            });
        }
    }
}
