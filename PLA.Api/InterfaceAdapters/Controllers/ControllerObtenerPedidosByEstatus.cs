namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidosByEstatus : IControllerObtenerPedidosByEstatus
{
    private readonly IObtenerPedidosByEstatusInputPort _inputPort;
    public ControllerObtenerPedidosByEstatus(IObtenerPedidosByEstatusInputPort inputPort) =>
        _inputPort = inputPort;    

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoByDay>> respuesta)> ObtenerPedidosByEstatus(bool estatus, int idUsuario)
    {
		try
		{
            var pedidosByDay = await _inputPort.Handler(estatus, idUsuario);
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
