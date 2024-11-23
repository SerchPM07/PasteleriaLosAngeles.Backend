
namespace PLA.Api.ApplicationBusinessRules.UseCases.Pedidos;

public class ObtenerPedidosFiltradosHandler : IObtenerPedidosFiltradosInputPort
{
    public ValueTask<List<PedidoDTO>> Handler(string filtrado, int idUsuario)
    {
        throw new NotImplementedException();
    }
}

