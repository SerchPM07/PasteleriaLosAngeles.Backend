
namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosHandler : IObtenerPedidosInputPort
{
    public ValueTask<List<PedidoDTO>> Handler(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario)
    {
        throw new NotImplementedException();
    }
}
