namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerLoginUsuario : IControllerLoginUsuario
{
    private readonly ILoginUsuarioInputPort _inputPort;

    public ControllerLoginUsuario(ILoginUsuarioInputPort inputPort) =>
    _inputPort = inputPort;

    public async ValueTask<(int statusCode, (LoginResultDTO loginResult, string mensaje))> LoginUsuario(UsuarioDTO usuario)
    {
        try
        {
            ((bool estatusOperacion, string mensaje), LoginResultDTO loginResult) = await _inputPort.Handler(usuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, (loginResult,
                 mensaje));
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, (null, "Error en el servidor"));
        }
    }
}
