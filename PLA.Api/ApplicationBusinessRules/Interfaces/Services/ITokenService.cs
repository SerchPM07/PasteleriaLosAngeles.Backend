namespace PLA.Api.ApplicationBusinessRules.Interfaces.Services
{
    public interface ITokenService
    {
        ValueTask<string> CreateToken(UsuarioDTO usuario);
    }
}
