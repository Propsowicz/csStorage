namespace csStorage.Exceptions;

public class ThisKeyAlreadyExistsException : Exception
{
	public ThisKeyAlreadyExistsException() : base("This key value already exists") { }
}
