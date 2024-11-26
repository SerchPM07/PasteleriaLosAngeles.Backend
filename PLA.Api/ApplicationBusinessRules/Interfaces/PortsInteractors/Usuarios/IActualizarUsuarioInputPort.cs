namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors.Usuarios;

public interface IActualizarUsuarioInputPort : IPort<(bool operacion, string mensaje), UsuarioDTO, int>
{
}

