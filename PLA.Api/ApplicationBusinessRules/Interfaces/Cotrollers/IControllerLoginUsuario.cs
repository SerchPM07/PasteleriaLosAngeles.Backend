namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerLoginUsuario
{
    ValueTask<(int statusCode, LoginResultDTO loginResult)> LoginUsuario(UsuarioDTO usuario);
}
