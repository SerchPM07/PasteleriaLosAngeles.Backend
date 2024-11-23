namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors.Usuarios;

public interface ILoginUsuarioInputPort : IPort<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult), UsuarioDTO>
{
}
