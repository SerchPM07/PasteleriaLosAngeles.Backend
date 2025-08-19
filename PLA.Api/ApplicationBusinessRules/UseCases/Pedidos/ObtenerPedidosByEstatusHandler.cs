namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosByEstatusHandler : IObtenerPedidosByEstatusInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidosByEstatusHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<List<PedidoDTO>> Handler(bool estatus, int idUsuario)
    {
        var pedidos = await _pedidosRepocitory.GetPedidosByEstatus(estatus);        
        if (pedidos.IsNullOrEmpty())
            return null;

        return pedidos;
    }
}
