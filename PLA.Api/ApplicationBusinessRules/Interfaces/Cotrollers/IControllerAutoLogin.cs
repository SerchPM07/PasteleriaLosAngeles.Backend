namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerAutoLogin
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<LoginResultDTO> respuesta)> AutoLogin(int idUsuario);
}
