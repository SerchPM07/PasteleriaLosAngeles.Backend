namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IUsuariosRepocitory : IRepocitoryBase<Usuario>
{
    ValueTask<Usuario> GetUsuarioById(int id);
    ValueTask<Usuario> GetUsuarioByTelefono(string telefono);
    ValueTask<string> GetPassword(long idUsuario);
    ValueTask<bool> UpdatePassword(long idUsuario, PasswordDTO password);
}
