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
        var listOfcsKeys = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        var isKeyUnique = !listOfcsKeys.Any(x => x.csKey == this.csKey);
        if (!isKeyUnique)
        {
            throw new ThisKeyAlreadyExistsException();
        }
        return isKeyUnique;
    }

    private bool DoesKeyExists()
    {
        var listOfcsKeys = ConvertGenericListToEntityBaseModelList(this.GetRecords());

        return listOfcsKeys.Any(x => x.csKey == this.csKey);
    }
}
