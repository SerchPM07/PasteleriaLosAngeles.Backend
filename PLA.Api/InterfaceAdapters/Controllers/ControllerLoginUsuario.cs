namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerLoginUsuario : IControllerLoginUsuario
{
    private readonly ILoginUsuarioInputPort _inputPort;

    public ControllerLoginUsuario(ILoginUsuarioInputPort inputPort) =>
    _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<LoginResultDTO> respuesta)> LoginUsuario(UsuarioDTO usuario)
    {
        try
        {
            ((bool estatusOperacion, string mensaje), LoginResultDTO loginResult) = await _inputPort.Handler(usuario);
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
