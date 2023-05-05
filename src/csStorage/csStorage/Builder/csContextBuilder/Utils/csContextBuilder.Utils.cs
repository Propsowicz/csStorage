using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    private T GetRecordByKey(string csKey)
    {
        var entityBaseModelList = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKey == csKey).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }
}
