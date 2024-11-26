namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerActualizarUsuario
{
    ValueTask<(int statusCode, string mensaje)> ActualizarUsuario(UsuarioDTO usuario, int idUsuario);
}
