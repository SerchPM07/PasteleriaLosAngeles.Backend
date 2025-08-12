namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerActualizarPassword : IControllerActualizarPassword
{
    private readonly IActualizarPasswordInputPort _inputPort;
    public ControllerActualizarPassword(IActualizarPasswordInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<string> respuesta)> ActualizarPassword(PasswordDTO password, int idUsuario)
    {
        try
        {
            (bool estatusOperacion, string mensaje) = await _inputPort.Handler(idUsuario, password);
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

