namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors.Pedidos;

public interface IRegistrarPedidoInputPort : IPort<(bool estatusOperacion, string mensaje), PedidoDTO, int>
{
}
