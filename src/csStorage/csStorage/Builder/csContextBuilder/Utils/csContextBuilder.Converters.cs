using csStorage.Base.csEntityBaseModel;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    private T ConvertObjectToGenericT(object entity)
    {
        if (entity is T)
        {
            return (T)entity;
        }
        try
        {
            return (T)Convert.ChangeType(entity, typeof(T));
        }
        catch (InvalidCastException)
        {
            throw new Exception("Couldn't convert object to generic class");
        }
    }

    private List<T> ConvertEntityBaseModelListToGenericList(IEnumerable<csEntityBaseModel<T>> entityBaseModelList)
    {
        List<T> genericList = new();

        foreach (var record in entityBaseModelList)
        {
            genericList.Add((T)Convert.ChangeType(record, typeof(T))
                ?? throw new Exception("Couldn't convert csEntityBaseModel to generic class"));
        }

        return genericList;
    }

    private List<csEntityBaseModel<T>> ConvertGenericListToEntityBaseModelList(IEnumerable<T> genericList)
    {
        List<csEntityBaseModel<T>> entityBaseModelList = new();

        foreach (var record in genericList)
        {
            entityBaseModelList.Add(record as csEntityBaseModel<T>
                ?? throw new Exception("Couldn't convert generic class to csEntityBaseModel"));
        }

        return entityBaseModelList;
    }
}
