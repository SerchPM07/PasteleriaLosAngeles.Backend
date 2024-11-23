namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors.Usuarios;

public interface IRegistrarUsuarioInputPort : IPort<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult), UsuarioDTO>
{
}

