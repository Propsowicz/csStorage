using csStorage.Base.csEntityBaseModel;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Add new entity to csv file. New entity need to have unique key.
    /// </summary>
    /// <param name="entity"></param>
    public void Add(csEntityBaseModel<T> entity)
    {
        var entietiesToAdd = this.GetEntietiesToAddInAddMethod(entity);
        this.WriteRecords(entietiesToAdd);
    }

    /// <summary>
    /// Asynchronously add new entity to csv file. New entity need to have unique key.
    /// </summary>
    /// <param name="entity"></param>
    public async Task AddAsync(csEntityBaseModel<T> entity)
    {
        var entietiesToAdd = this.GetEntietiesToAddInAddMethod(entity);
        await this.WriteRecordsAsync(entietiesToAdd);
    }    
}
