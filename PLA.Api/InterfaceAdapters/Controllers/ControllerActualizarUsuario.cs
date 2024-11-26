namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerActualizarUsuario : IControllerActualizarUsuario
{
    public ValueTask<(int statusCode, string mensaje)> ActualizarUsuario(UsuarioDTO usuario, int idUsuario)
    {
        throw new NotImplementedException();
    }
}

