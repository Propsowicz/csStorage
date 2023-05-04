using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Get all records from csv file.
    /// </summary>
    /// <returns>IEnumerable<entieties></returns>
    public IEnumerable<T> Get()
    {
        return this.GetRecords();
    }

    /// <summary>
    /// Get record with specified string Key.
    /// </summary>
    /// <param name="csKeyValue"></param>
    /// <returns>Entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Get(string csKeyValue)
    {
        var entityBaseModelList = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKeyValue == csKeyValue).FirstOrDefault() 
            ?? throw new EntityDoesntExistsException());            
    }

    /// <summary>
    /// Get record with specified Guid Key.
    /// </summary>
    /// <param name="csKeyValue"></param>
    /// <returns>Entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Get(Guid csKeyValue)
    {
        var entityBaseModelList = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKeyValue == csKeyValue.ToString()).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }

    /// <summary>
    /// Get record with specified int Key.
    /// </summary>
    /// <param name="csKeyValue"></param>
    /// <returns>Entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Get(int csKeyValue)
    {
        var entityBaseModelList = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKeyValue == csKeyValue.ToString()).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }     
}
