namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerActualizarUsuario : IControllerActualizarUsuario
{
    private readonly IActualizarUsuarioInputPort _inputPort;
    public ControllerActualizarUsuario(IActualizarUsuarioInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, string mensaje)> ActualizarUsuario(UsuarioDTO usuario, int idUsuario)
    {
        try
        {
            (bool estatusOperacion, string mensaje) = await _inputPort.Handler(usuario, idUsuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, mensaje);
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, "Error en el servidor");
        }
    }
}

