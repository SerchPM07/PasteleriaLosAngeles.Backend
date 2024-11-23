namespace PLA.Api.EnterpriseBusinessRules.Entities.Repositories;

public interface IRepocitoryBase<T>
{
    public ValueTask<T> Add(T parameter);
    public ValueTask<T> Update(T parameter);
    public ValueTask<T> Get(T parameter);

}

