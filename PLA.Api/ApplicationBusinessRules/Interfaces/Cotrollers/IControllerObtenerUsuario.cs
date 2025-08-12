namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerUsuario
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<UsuarioDTO> respuesta)> ObtenerUsuario(int idUsuario);
}
