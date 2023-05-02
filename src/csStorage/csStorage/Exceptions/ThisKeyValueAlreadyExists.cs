namespace csStorage.Exceptions;

public class ThisKeyValueAlreadyExists : Exception
{
	public ThisKeyValueAlreadyExists() : base("This key value already exists") { }
}
