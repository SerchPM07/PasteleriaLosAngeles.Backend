namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors.Pedidos;

public interface IActualizarPedidoInputPort : IPort<(bool estatusOperacion, string mensaje), PedidoDTO, int>
{
}
