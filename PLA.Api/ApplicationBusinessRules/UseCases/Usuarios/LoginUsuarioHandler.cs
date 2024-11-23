
namespace PLA.Api.ApplicationBusinessRules.UseCases.Usuarios;

public class LoginUsuarioHandler : ILoginUsuarioInputPort
{
    public ValueTask<((bool estatusOperacion, string mensaje), LoginResultDTO loginResult)> Handler(UsuarioDTO usuario)
    {
        throw new NotImplementedException();
    }
}

