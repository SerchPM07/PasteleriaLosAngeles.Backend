namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerRegistrarUsuario : IControllerRegistrarUsuario
{
    private readonly IRegistrarUsuarioInputPort _inputPort;
    public ControllerRegistrarUsuario(ITokenService tokenService, IRegistrarUsuarioInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, LoginResultDTO loginResult)> RegistrarUsuario(UsuarioDTO usuario)
    {
        try
        {
            ((bool estatusOperacion, string mensaje), LoginResultDTO loginResult) = await _inputPort.Handler(usuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, loginResult);
        }
        catch (Exception e)
        {
            return (StatusCodes.Status500InternalServerError, null);
        }
    }
}
