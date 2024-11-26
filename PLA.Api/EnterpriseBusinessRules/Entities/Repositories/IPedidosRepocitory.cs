namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IPedidosRepocitory : IRepocitoryBase<Pedido>
{
    ValueTask<List<Pedido>> GetPedidosByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd);
    ValueTask<List<Pedido>> GetPedidosByFilter(string filter);
    ValueTask<Pedido> GetPedidoById(long id);
}

