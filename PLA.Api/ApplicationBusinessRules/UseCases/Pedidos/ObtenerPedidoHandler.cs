namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidoHandler : IObtenerPedidoInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidoHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<PedidoDTO> Handler(long idPedido, int idUsuario)
    {
        if (idPedido.Equals(0))
            return null;

        var pedido = await _pedidosRepocitory.GetPedidoById(idPedido);
        if(pedido.IsNull())
            return null;

        return pedido;
    }
}