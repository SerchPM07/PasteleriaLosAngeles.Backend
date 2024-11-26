namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerLoginUsuario : IControllerLoginUsuario
{
    public ValueTask<(int statusCode, LoginResultDTO loginResult)> LoginUsuario(UsuarioDTO usuario)
    {
        throw new NotImplementedException();
    }
}
