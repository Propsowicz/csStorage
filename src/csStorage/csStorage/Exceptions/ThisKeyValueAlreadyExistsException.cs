namespace csStorage.Exceptions;

public class ThisKeyValueAlreadyExistsException : Exception
{
	public ThisKeyValueAlreadyExistsException() : base("This key value already exists") { }
}
