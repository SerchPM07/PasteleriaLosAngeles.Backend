
namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class RegistrarPedidoHandler : IRegistrarPedidoInputPort
{
    public ValueTask<(bool estatusOperacion, string mensaje)> Handler(PedidoDTO pedido, int idUsuario)
    {
        throw new NotImplementedException();
    }
}
