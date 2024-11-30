namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerRegistrarUsuario
{
    ValueTask<(int statusCode, RespuestaGenericaDTO<LoginResultDTO> respuesta)> RegistrarUsuario(UsuarioDTO usuario);
}
