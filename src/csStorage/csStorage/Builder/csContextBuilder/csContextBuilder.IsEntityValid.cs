using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    private void IsEntityValid()
    {
        if (this.Entity == null)
        {
            throw new NullReferenceException();
        }

        if (!typeof(T).IsSubclassOf(typeof(csEntityBaseModel<T>)))
        {
            throw new EntityDoesntInheritFromEntityBaseModelException();
        }
    }
}
