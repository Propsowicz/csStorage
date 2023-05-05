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
        this.IsEntityValid(entity);
        var entietiesToAdd = new List<T>();
        this.SetCsKey(entity);
        this.SetEntity(entity);
        
        if (File.Exists(StoragePath))
        {
            var allRecords = this.GetRecords();
            this.IsKeyUnique();
            entietiesToAdd.AddRange(allRecords);            
        }                            
        entietiesToAdd.Add(ConvertObjectToGenericT(this.Entity));

        this.WriteRecords(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }      
}
