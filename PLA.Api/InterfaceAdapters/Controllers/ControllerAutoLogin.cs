using PLA.Api.Entities.POCO;

namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerAutoLogin : IControllerAutoLogin
{
    private readonly IAutoLoginInputPort _inputPort;

    public ControllerAutoLogin(IAutoLoginInputPort inputPort) =>
    _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<LoginResultDTO> respuesta)> AutoLogin(int idUsuario)
    {
        try
        {
            ((bool estatusOperacion, string mensaje), LoginResultDTO loginResult) = await _inputPort.Handler(idUsuario);
            return (!estatusOperacion ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK, new RespuestaGenericaDTO<LoginResultDTO>
            {
                Mensaje = mensaje,
                Objeto = loginResult,
                EstatusOperacion = estatusOperacion
            });
        }
        catch (Exception)
        {
            return (StatusCodes.Status500InternalServerError, new RespuestaGenericaDTO<LoginResultDTO>
            {
                Mensaje = "Ocurrio un error en el servidro",
                Objeto = null,
                EstatusOperacion = false
            });
        }
    }
}
