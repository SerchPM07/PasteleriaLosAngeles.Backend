namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerRegistrarUsuario : IControllerRegistrarUsuario
{
    public ValueTask<(int statusCode, LoginResultDTO loginResult)> RegistrarUsuario(UsuarioDTO usuario)
    {
        throw new NotImplementedException();
    }
}
