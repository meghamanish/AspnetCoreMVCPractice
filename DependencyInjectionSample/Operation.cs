using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Classes;

public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationSingletonInstance
{
	Guid _guid;
	public Operation() : this(Guid.NewGuid())
	{

	}

	public Operation(Guid guid)
	{
		_guid = guid;
	}

	public Guid OperationId => _guid;
}

public class OperationTransient: Operation
{

}

public class OperationScoped : Operation
{

}

public class OperationSingleton : Operation
{

}

public class OperationSingletonInstance: Operation
{
	Guid _guid;

	public OperationSingletonInstance(Guid guid)
	{
		_guid = guid;
	}
}