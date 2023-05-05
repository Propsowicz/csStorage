using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Delete an Entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public void Delete(csEntityBaseModel<T> entity)
    {
        var isEntityValid = this.IsEntityValid(entity);
        var entietiesToAdd = new List<T>();
        this.SetCsKey(entity);
        this.SetEntity(entity);

        if (File.Exists(StoragePath))
        {
            var allRecords = this.GetRecords();
            var doesKeyExists = this.DoesKeyExists();
            if (!doesKeyExists)
            {
                throw new EntityDoesntExistsException();
            }

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
}
