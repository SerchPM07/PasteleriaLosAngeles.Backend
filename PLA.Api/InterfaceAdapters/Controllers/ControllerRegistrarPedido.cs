namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerRegistrarPedido : IControllerRegistrarPedido
{
    public ValueTask<(int statusCode, string mensaje)> RegistrarPedido(PedidoDTO pedido, int idUsuario)
    {
        throw new NotImplementedException();
    }
}

