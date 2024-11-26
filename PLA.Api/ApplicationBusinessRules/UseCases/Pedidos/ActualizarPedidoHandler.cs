namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ActualizarPedidoHandler : IActualizarPedidoInputPort
{
    public ValueTask<(bool estatusOperacion, string mensaje)> Handler(PedidoDTO pedido, int idUsuario)
    {
        throw new NotImplementedException();
    }
}
