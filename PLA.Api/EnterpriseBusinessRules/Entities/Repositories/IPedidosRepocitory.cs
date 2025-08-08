namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IPedidosRepocitory : IRepocitoryBase<PedidoDTO>
{
    ValueTask<List<PedidoDTO>> GetPedidosByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd);
    ValueTask<List<PedidoDTO>> GetPedidosByFilter(string filter);
    ValueTask<PedidoDTO> GetPedidoById(long id);
}

