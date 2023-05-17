using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Update an entity.
    /// </summary>
    /// <param name="entity"></param>
    public void Update(csEntityBaseModel<T> entity)
    {
        var entitiesToAdd = this.GetEntitiesToAddInUpdateMethod(entity);
        this.WriteRecords(entitiesToAdd);
        this.SetSuccessResult();
    }

    /// <summary>
    /// Asynchronously update an entity.
    /// </summary>
    /// <param name="entity"></param>
    public async Task UpdateAsync(csEntityBaseModel<T> entity)
    {
        var entitiesToAdd = this.GetEntitiesToAddInUpdateMethod(entity);
        await this.WriteRecordsAsync(entitiesToAdd);
        this.SetSuccessResult();
    }
}
