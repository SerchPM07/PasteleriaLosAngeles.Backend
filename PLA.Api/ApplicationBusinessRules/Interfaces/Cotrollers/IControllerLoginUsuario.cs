namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerLoginUsuario
{
    ValueTask<(int statusCode, (LoginResultDTO loginResult, string mensaje))> LoginUsuario(UsuarioDTO usuario);
}
