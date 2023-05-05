using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

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
        this.IsEntityValid(entity);
        var entietiesToAdd = new List<T>();
        this.SetCsKey(entity);
        this.SetEntity(entity);

        if (File.Exists(StoragePath))
        {
            var allRecords = this.GetRecords();
            this.DoesKeyExists();            

            var recordsWithoutUpdatedEntity = this.ConvertGenericListToEntityBaseModelList(allRecords).Where(x => x.csKey != this.csKey);
            var genericRecordsWithoutUpdatedEntity = this.ConvertEntityBaseModelListToGenericList(recordsWithoutUpdatedEntity);

            entietiesToAdd.AddRange(genericRecordsWithoutUpdatedEntity);
                        
            entietiesToAdd.Add(ConvertObjectToGenericT(this.Entity));            
        }
        else
        {
            throw new EntityDoesntExistsException();
        }

        this.WriteRecords(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }      
}
