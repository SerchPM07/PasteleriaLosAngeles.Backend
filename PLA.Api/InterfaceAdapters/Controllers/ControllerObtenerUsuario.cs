namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerObtenerUsuario : IControllerObtenerUsuario
{
    public ValueTask<(int statusCode, UsuarioDTO usuario)> ObtenerUsuario(int idUsuario)
    {
        throw new NotImplementedException();
    }
}

