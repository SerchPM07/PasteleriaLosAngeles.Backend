namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerRegistrarUsuario
{
    ValueTask<(int statusCode, LoginResultDTO loginResult)> RegistrarUsuario(UsuarioDTO usuario);
}
