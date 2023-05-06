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
        var entietiesToAdd = this.GetEntietiesToAddInAddMethod(entity);
        this.WriteRecords(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }

    /// <summary>
    /// Asynchronously add new entity to csv file. New entity need to have unique key.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Created entity.</returns>
    public async Task<T> AddAsync(csEntityBaseModel<T> entity)
    {
        var entietiesToAdd = this.GetEntietiesToAddInAddMethod(entity);
        await this.WriteRecordsAsync(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }    
}
