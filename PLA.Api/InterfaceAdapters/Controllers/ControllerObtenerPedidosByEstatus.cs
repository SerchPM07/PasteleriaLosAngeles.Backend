namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidosByEstatus : IControllerObtenerPedidosByEstatus
{
    private readonly IObtenerPedidosByEstatusInputPort _inputPort;
    public ControllerObtenerPedidosByEstatus(IObtenerPedidosByEstatusInputPort inputPort) =>
        _inputPort = inputPort;    

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<List<PedidoDTO>> respuesta)> ObtenerPedidosByEstatus(bool estatus, int idUsuario)
    {
		try
		{
            var pedidos = await _inputPort.Handler(estatus, idUsuario);
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
