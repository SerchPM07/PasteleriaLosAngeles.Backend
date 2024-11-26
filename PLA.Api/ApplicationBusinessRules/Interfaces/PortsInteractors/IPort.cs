namespace PLA.Api.ApplicationBusinessRules.Interfaces.PortsInteractors;

public interface IPort<TResult>
{
    ValueTask<TResult> Handler();
}

public interface IPort<TResult, T>
{
    ValueTask<TResult> Handler(T toHanlder);
}

public interface IPort<TResult, T1, T2>
{
    ValueTask<TResult> Handler(T1 toHandler, T2 toHandler2);
}

public interface IPort<TResult, T1, T2, T3>
{
    ValueTask<TResult> Handler(T1 toHandler, T2 toHandler2, T3 toHandler3);
}

