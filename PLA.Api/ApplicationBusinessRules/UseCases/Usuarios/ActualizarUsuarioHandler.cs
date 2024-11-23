
namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class ActualizarUsuarioHandler : IActualizarUsuarioInputPort
{
    public ValueTask<(bool operacion, string mensaje)> Handler(UsuarioDTO usuario, int idUsuario)
    {
        throw new NotImplementedException();
    }
}