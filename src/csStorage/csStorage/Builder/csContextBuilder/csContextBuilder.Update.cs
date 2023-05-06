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
        var entietiesToAdd = this.GetEntietiesToAddInUpdateMethod(entity);
        this.WriteRecords(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }

    /// <summary>
    /// Asynchronously update an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Updated entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public async Task<T> UpdateAsync(csEntityBaseModel<T> entity)
    {
        var entietiesToAdd = this.GetEntietiesToAddInUpdateMethod(entity);
        await this.WriteRecordsAsync(entietiesToAdd);

        return ConvertObjectToGenericT(this.Entity);
    }
}
