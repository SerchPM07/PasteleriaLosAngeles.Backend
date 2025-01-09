namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors.Usuarios;

public interface IActualizarPasswordInputPort : IPort<(bool estatusOperacion, string mensaje), int, PasswordDTO>
{
}
