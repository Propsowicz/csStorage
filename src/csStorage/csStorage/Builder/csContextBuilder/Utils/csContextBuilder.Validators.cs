using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    public bool IsEntityValid(csEntityBaseModel<T> entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (!typeof(T).IsSubclassOf(typeof(csEntityBaseModel<T>)))
        {
            return true;
        }
        return true;
    }

    private bool IsKeyUnique()
    {
        var listOfcsKeyValues = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        var isKeyUnique = !listOfcsKeyValues.Any(x => x.csKeyValue == this.csKeyValue);
        if (!isKeyUnique)
        {
            throw new ThisKeyValueAlreadyExistsException();
        }
        return isKeyUnique;
    }

    private bool DoesKeyExists()
    {
        var listOfcsKeyValues = ConvertGenericListToEntityBaseModelList(this.GetRecords());

        return listOfcsKeyValues.Any(x => x.csKeyValue == this.csKeyValue);
    }
}
