using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Delete an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public void Delete(csEntityBaseModel<T>? entity)
    {
        var entietiesToAdd = this.GetEntietiesToAddInDeleteMethod(entity);

        this.WriteRecords(entietiesToAdd);
    }

    /// <summary>
    /// Delete an entity by string key.
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(string csKey)
    {
        var entity = this.GetRecordByKey(csKey) as csEntityBaseModel<T>;
        this.Delete(entity);
    }

    /// <summary>
    /// Delete an entity by Guid key
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(Guid csKey)
    {
        var entity = this.GetRecordByKey(csKey.ToString()) as csEntityBaseModel<T>;
        this.Delete(entity);
    }

    /// <summary>
    /// Delete an entity by int key
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(int csKey)
    {
        var entity = this.GetRecordByKey(csKey.ToString()) as csEntityBaseModel<T>;
        this.Delete(entity);
    }

    /// <summary>
    /// Delete an entity by DateTime key
    /// </summary>
    /// <param name="csKey"></param>
    public void Delete(DateTime csKey)
    {
        var entity = this.GetRecordByKey(csKey.ToString()) as csEntityBaseModel<T>;
        this.Delete(entity);
    }

    /// <summary>
    /// Asynchronously delete an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public async Task DeleteAsync(csEntityBaseModel<T>? entity)
    {
        var entietiesToAdd = this.GetEntietiesToAddInDeleteMethod(entity);

        await this.WriteRecordsAsync(entietiesToAdd);
    }

    /// <summary>
    /// Asynchronously delete an entity by string key.
    /// </summary>
    /// <param name="csKey"></param>
    public async Task DeleteAsync(string csKey)
    {
        var entity = await this.GetRecordByKeyAsync(csKey) as csEntityBaseModel<T>;
        await this.DeleteAsync(entity);
    }

    /// <summary>
    /// Asynchronously delete an entity by Guid key
    /// </summary>
    /// <param name="csKey"></param>
    public async Task DeleteAsync(Guid csKey)
    {
        var entity = await this.GetRecordByKeyAsync(csKey.ToString()) as csEntityBaseModel<T>;
        await this.DeleteAsync(entity);
    }

    /// <summary>
    /// Asynchronously delete an entity by int key
    /// </summary>
    /// <param name="csKey"></param>
    public async Task DeleteAsync(int csKey)
    {
        var entity = await this.GetRecordByKeyAsync(csKey.ToString()) as csEntityBaseModel<T>;
        await this.DeleteAsync(entity);
    }

    /// <summary>
    /// Asynchronously delete an entity by DateTime key
    /// </summary>
    /// <param name="csKey"></param>
    public async Task DeleteAsync(DateTime csKey)
    {
        var entity = await this.GetRecordByKeyAsync(csKey.ToString()) as csEntityBaseModel<T>;
        await this.DeleteAsync(entity);
    }
}
