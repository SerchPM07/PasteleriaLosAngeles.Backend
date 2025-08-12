namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors.Usuarios;

public interface IAutoLoginInputPort : IPort<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult), int>
{
}
