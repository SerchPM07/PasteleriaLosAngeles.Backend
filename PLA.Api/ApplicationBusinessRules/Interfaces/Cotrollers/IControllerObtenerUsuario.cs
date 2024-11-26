namespace PLA.Api.ApplicationBusinessRules.Interfaces.Cotrollers;

public interface IControllerObtenerUsuario
{
    ValueTask<(int statusCode, UsuarioDTO usuario)> ObtenerUsuario(int idUsuario);
}
