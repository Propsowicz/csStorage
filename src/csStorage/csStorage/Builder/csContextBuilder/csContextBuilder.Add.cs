using csStorage.Base.csEntityBaseModel;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Add new entity to csv file. New entity need to have unique key.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Created entity.</returns>
    public T Add(csEntityBaseModel<T> entity)
    {
        var isEntityValid = this.IsEntityValid(entity);
        var entietiesToAdd = new List<T>();
        this.SetCsKeyValue(entity);
        this.SetEntity(entity);
        
        if (File.Exists(StoragePath))
        {
            var allRecords = this.GetRecords();
            var isKeyUnique = this.IsKeyUnique();
            entietiesToAdd.AddRange(allRecords);

            if (isKeyUnique && isEntityValid)
            {
                entietiesToAdd.Add(ConvertObjectToGenericT(this.Entity));
            }
        }
        else
        {                      
            if (isEntityValid)
            {
                entietiesToAdd.Add(ConvertObjectToGenericT(this.Entity));
            }
        }

        this.WriteRecords(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }      
}
