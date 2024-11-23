namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IPedidosRepocitory : IRepocitoryBase<Pedido>
{
    public ValueTask<List<Pedido>> GetPedidosByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd);
    public ValueTask<List<Pedido>> GetPedidosByFilter(string filter);
}

