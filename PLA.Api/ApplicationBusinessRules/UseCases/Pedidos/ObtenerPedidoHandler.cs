namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidoHandler : IObtenerPedidoInputPort
{
    public ValueTask<PedidoDTO> Handler(long idPedido, int idUsuario)
    {
        throw new NotImplementedException();
    }
}