namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerActualizarPassword
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<string> respuesta)> ActualizarPassword(PasswordDTO password, int idUsuario);
}
