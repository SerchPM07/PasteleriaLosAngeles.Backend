namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerActualizarUsuario
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<string> respuesta)> ActualizarUsuario(UsuarioDTO usuario, int idUsuario);
}
