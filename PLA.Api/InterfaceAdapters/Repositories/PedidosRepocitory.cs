namespace PLA.Api.InterfaceAdapters.Repositories;

public class PedidosRepocitory : IPedidosRepocitory
{
    public ValueTask<Pedido> Add(Pedido parameter)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Pedido> GetPedidoById(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<List<Pedido>> GetPedidosByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd)
    {
        throw new NotImplementedException();
    }

    public ValueTask<List<Pedido>> GetPedidosByFilter(string filter)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Pedido> Update(Pedido parameter)
    {
        throw new NotImplementedException();
    }
}
