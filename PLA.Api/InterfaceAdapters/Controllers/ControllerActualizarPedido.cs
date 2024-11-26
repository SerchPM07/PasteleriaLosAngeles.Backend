namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerActualizarPedido : IControllerActualizarPedido
{
    public ValueTask<(int statusCode, string mensaje)> ActualizarPedido(PedidoDTO pedido, int idUsuario)
    {
        throw new NotImplementedException();
    }
}
