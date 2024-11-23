
namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class RegistrarUsuarioHandler : IRegistrarUsuarioInputPort
{
    public ValueTask<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult)> Handler(UsuarioDTO usuario)
    {
        throw new NotImplementedException();
    }
}
