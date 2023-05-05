using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    public void IsEntityValid(csEntityBaseModel<T>? entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }       
    }

    private void IsKeyUnique()
    {
        var listOfcsKeys = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        if (listOfcsKeys.Any(x => x.csKey == this.csKey))
        {
            throw new ThisKeyAlreadyExistsException();
        }
    }

    private void DoesKeyExists()
    {
        var listOfcsKeys = ConvertGenericListToEntityBaseModelList(this.GetRecords());

        if (!listOfcsKeys.Any(x => x.csKey == this.csKey))
        {
            throw new EntityDoesntExistsException();
        }
    }
}
