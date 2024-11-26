namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IActividadesRepocitory : IRepocitoryBase<RegistroActividad>
{
    public ValueTask<RegistroActividad> Get(RegistroActividad registro);
}

