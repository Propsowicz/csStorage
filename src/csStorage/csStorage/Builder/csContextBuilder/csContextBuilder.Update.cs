using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;
using csStorage.Shared;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Update an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Updated entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Update(csEntityBaseModel<T> entity)
    {
        var isEntityValid = this.IsEntityValid(entity);
        var entietiesToAdd = new List<T>();
        this.SetCsKeyValue(entity);
        this.SetEntity(entity);

        if (File.Exists(StoragePath))
        {
            var allRecords = this.GetRecords();
            var doesKeyExists = this.DoesKeyExists();
            if (!doesKeyExists)
            {
                throw new EntityDoesntExistsException();
            }

            var recordsWithoutUpdatedEntity = this.ConvertGenericListToEntityBaseModelList(allRecords).Where(x => x.csKeyValue != this.csKeyValue);
            var genericRecordsWithoutUpdatedEntity = this.ConvertEntityBaseModelListToGenericList(recordsWithoutUpdatedEntity);

            entietiesToAdd.AddRange(genericRecordsWithoutUpdatedEntity);

            if (doesKeyExists && isEntityValid)
            {
                entietiesToAdd.Add(ConvertObjectToGenericT(this.Entity));
            }
        }
        else
        {
            throw new EntityDoesntExistsException();
        }

        this.WriteRecords(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }      
}
