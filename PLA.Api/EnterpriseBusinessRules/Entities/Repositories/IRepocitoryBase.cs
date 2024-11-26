namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IRepocitoryBase<T>
{
    ValueTask<T> Add(T parameter);
    ValueTask<T> Update(T parameter);
}

