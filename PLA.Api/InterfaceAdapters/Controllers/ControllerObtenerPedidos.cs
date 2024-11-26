namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerPedidos : IControllerObtenerPedidos
{
    public ValueTask<(int statusCode, List<PedidoDTO> pedidios)> ObtenerPedidos(DateTime dateTimeStart, DateTime dateTimeEnd, int idUsuario)
    {
        throw new NotImplementedException();
    }
}
