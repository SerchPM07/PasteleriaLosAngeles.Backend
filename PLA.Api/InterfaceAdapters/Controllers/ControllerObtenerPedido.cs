
namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedido : IControllerObtenerPedido
{
    public ValueTask<(int statusCode, PedidoDTO pedido)> ObtenerPedido(long idPedido, int idUsuario)
    {
        throw new NotImplementedException();
    }
}
