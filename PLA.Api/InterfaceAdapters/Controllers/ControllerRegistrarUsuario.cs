namespace PLA.Api.InterfaceAdapters.Controllers;

public class ControllerRegistrarUsuario : IControllerRegistrarUsuario
{
    private readonly IRegistrarUsuarioInputPort _inputPort;
    public ControllerRegistrarUsuario(ITokenService tokenService, IRegistrarUsuarioInputPort inputPort) =>
        _inputPort = inputPort;

    public async ValueTask<(int statusCode, RespuestaGenericaDTO<LoginResultDTO> respuesta)> RegistrarUsuario(UsuarioDTO usuario)
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
                Mensaje = "Ocurrrio un error en el servidor",
                Objeto = null,
                EstatusOperacion = false
            });
        }
    }
}
