namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IUsuariosRepocitory : IRepocitoryBase<Usuario>
{
    ValueTask<Usuario> GetUsuarioById(int id);
    ValueTask<Usuario> GetUsuarioByTelefono(string telefono);
}
