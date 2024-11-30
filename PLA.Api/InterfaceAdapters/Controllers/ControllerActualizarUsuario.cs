namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerActualizarUsuario : IControllerActualizarUsuario
{
    private readonly IActualizarUsuarioInputPort _inputPort;
    public ControllerActualizarUsuario(IActualizarUsuarioInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<string> respuesta)> ActualizarUsuario(UsuarioDTO usuario, int idUsuario)
    {
        try
        {
            (bool estatusOperacion, string mensaje) = await _inputPort.Handler(usuario, idUsuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, new RespuestaGenericaDTO<string>
            {
                Mensaje = string.Empty,
                Objeto = mensaje,
                EstatusOperacion = estatusOperacion
            });
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, new RespuestaGenericaDTO<string>
            {
                Mensaje = "Ocurrio un error en el servidor",
                Objeto = string.Empty,
                EstatusOperacion = false
            });
        }
    }
}

