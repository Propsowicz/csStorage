namespace csStorage.Exceptions;

public class EntityDoesntExistsException : Exception
{
    public EntityDoesntExistsException() : base("Entity doesn't exists") { }
}
