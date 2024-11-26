namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidosFiltrados : IControllerObtenerPedidosFiltrados
{
    public ValueTask<(int statusCode, List<PedidoDTO> pedidos)> ObtenerPedidosFiltrados(string filtrado, int idUsuario)
    {
        throw new NotImplementedException();
    }
}
