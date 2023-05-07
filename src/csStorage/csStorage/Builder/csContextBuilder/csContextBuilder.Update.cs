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
        var entietiesToAdd = this.GetEntietiesToAddInUpdateMethod(entity);
        this.WriteRecords(entietiesToAdd);
        this.SetSuccessResult();
    }

    /// <summary>
    /// Asynchronously update an entity.
    /// </summary>
    /// <param name="entity"></param>
    public async Task UpdateAsync(csEntityBaseModel<T> entity)
    {
        var entietiesToAdd = this.GetEntietiesToAddInUpdateMethod(entity);
        await this.WriteRecordsAsync(entietiesToAdd);
        this.SetSuccessResult();
    }
}
