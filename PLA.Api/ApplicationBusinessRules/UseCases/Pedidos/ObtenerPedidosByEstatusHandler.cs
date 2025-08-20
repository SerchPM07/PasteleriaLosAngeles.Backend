namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosByEstatusHandler : IObtenerPedidosByEstatusInputPort
{
    private readonly IPedidosRepocitory _pedidosRepocitory;
    private readonly IActividadesRepocitory _actividadesRepocitory;

    public ObtenerPedidosByEstatusHandler(IPedidosRepocitory pedidosRepocitory, IActividadesRepocitory actividadesRepocitory) =>
        (_pedidosRepocitory, _actividadesRepocitory) = (pedidosRepocitory, actividadesRepocitory);

    public async ValueTask<List<PedidoByDay>> Handler(bool estatus, int idUsuario)
    {
        var pedidos = await _pedidosRepocitory.GetPedidosByEstatus(estatus);       
        if (pedidos.IsNullOrEmpty())
            return null;

        List<PedidoByDay> pedidosByDay = new();
        pedidos.ForEach(p =>
        {
            var pedidoByDayTmp = pedidosByDay.FirstOrDefault(f => f.Dia.ToString("yyyy-MM-dd").Equals(p.FechaEntrega.ToString("yyyy-MM-dd")));
            if (pedidoByDayTmp.IsNotNull())
                pedidoByDayTmp.Pedidos.Add(p);
            else
            {
                pedidosByDay.Add(new PedidoByDay()
                {
                    Dia = new(p.FechaEntrega.Year, p.FechaEntrega.Month, p.FechaEntrega.Day),
                    Pedidos = [p]
                });
            }
        });
        return pedidosByDay;
    }
}
