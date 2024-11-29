using PLA.Api.ApplicationBusinessRules.Enums;

namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IActividadesRepocitory
{
    public ValueTask<bool> Registrar(RegistroActividad registro);

}

