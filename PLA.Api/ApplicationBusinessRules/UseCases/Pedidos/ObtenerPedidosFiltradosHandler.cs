namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosFiltradosHandler : IObtenerPedidosFiltradosInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidosFiltradosHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<List<PedidoDTO>> Handler(string filtrado, int idUsuario)
    {
        if (filtrado.IsNullOrEmpty())
            return null;

        var pedidos = await _pedidosRepocitory.GetPedidosByFilter(filtrado);
        if (pedidos.IsNullOrEmpty())
            return null;

        return pedidos;
    }
}

