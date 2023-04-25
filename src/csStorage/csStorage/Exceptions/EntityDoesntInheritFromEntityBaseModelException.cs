namespace csStorage.Exceptions;

internal class EntityDoesntInheritFromEntityBaseModelException : Exception
{
    public EntityDoesntInheritFromEntityBaseModelException() : base("Entity has to inherit from csEntityBaseModel") { }
}
