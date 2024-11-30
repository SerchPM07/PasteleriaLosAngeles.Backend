namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerLoginUsuario
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<LoginResultDTO> respuesta)> LoginUsuario(UsuarioDTO usuario);
}
