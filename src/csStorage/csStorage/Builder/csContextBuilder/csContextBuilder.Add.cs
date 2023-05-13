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
        var entitiesToAdd = this.GetEntitiesToAddInAddMethod(entity);
        this.WriteRecords(entitiesToAdd);
        this.SetSuccessResult();
    }

    /// <summary>
    /// Asynchronously add new entity to csv file. New entity need to have unique key.
    /// </summary>
    /// <param name="entity"></param>
    public async Task AddAsync(csEntityBaseModel<T> entity)
    {
        var entitiesToAdd = this.GetEntitiesToAddInAddMethod(entity);
        await this.WriteRecordsAsync(entitiesToAdd);
        this.SetSuccessResult();
    }    
}
