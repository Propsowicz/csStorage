using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Delete an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public void Delete(csEntityBaseModel<T>? entity)
    {
        this.IsEntityValid(entity);
        var entietiesToAdd = new List<T>();
        this.SetCsKey(entity!);
        this.SetEntity(entity!);

        if (File.Exists(StoragePath))
        {
            var allRecords = this.GetRecords();
            this.DoesKeyExists();            

            var recordsWithoutUpdatedEntity = this.ConvertGenericListToEntityBaseModelList(this.GetRecords()).Where(x => x.csKey != this.csKey);
            var genericRecordsWithoutUpdatedEntity = this.ConvertEntityBaseModelListToGenericList(recordsWithoutUpdatedEntity);

            entietiesToAdd.AddRange(genericRecordsWithoutUpdatedEntity);            
        }
        else
        {
            throw new EntityDoesntExistsException();
        }

        this.WriteRecords(entietiesToAdd);
    }

    /// <summary>
    /// Delete an entity by string key.
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(string csKey)
    {
        var entity = this.GetRecordByKey(csKey) as csEntityBaseModel<T>;
        this.Delete(entity);
    }

    /// <summary>
    /// Delete an entity by Guid key
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(Guid csKey)
    {
        var entity = this.GetRecordByKey(csKey.ToString()) as csEntityBaseModel<T>;
        this.Delete(entity);
    }

    /// <summary>
    /// Delete an entity by int key
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(int csKey)
    {
        var entity = this.GetRecordByKey(csKey.ToString()) as csEntityBaseModel<T>;
        this.Delete(entity);
    }

    /// <summary>
    /// Delete an entity by DateTime key
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(DateTime csKey)
    {
        var entity = this.GetRecordByKey(csKey.ToString()) as csEntityBaseModel<T>;
        this.Delete(entity);
    }
}
