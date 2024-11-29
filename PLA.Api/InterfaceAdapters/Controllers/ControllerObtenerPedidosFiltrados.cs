namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidosFiltrados : IControllerObtenerPedidosFiltrados
{
    private readonly IObtenerPedidosFiltradosInputPort _inputPort;
    public ControllerObtenerPedidosFiltrados(IObtenerPedidosFiltradosInputPort inputPort) =>
        _inputPort = inputPort;    

    public async ValueTask<(int statusCode, List<PedidoDTO> pedidos)> ObtenerPedidosFiltrados(string filtrado, int idUsuario)
    {
		try
		{
            var pedidos = await _inputPort.Handler(filtrado, idUsuario);
            return (pedidos.IsNullOrEmpty() ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, pedidos);
        }
        catch (Exception)
		{
            return (StatusCodes.Status500InternalServerError, null);
		}
    }
}
