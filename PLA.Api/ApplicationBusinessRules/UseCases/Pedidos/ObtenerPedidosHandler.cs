namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosHandler : IObtenerPedidosInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidosHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<List<PedidoDTO>> Handler(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario)
    {
        var pedidos = await _pedidosRepocitory.GetPedidosByDateTime(dateTimeStart, dateTimeEnd);        
        if (pedidos.IsNullOrEmpty())
            return null;

        return pedidos;
    }
}
