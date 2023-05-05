using csStorage.Exceptions;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Get all records from csv file.
    /// </summary>
    /// <returns>IEnumerable<entieties></returns>
    public IEnumerable<T> Get()
    {
        return this.GetRecords();
    }

    /// <summary>
    /// Get record with specified string Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Get(string csKey)
    {
        return this.GetRecordByKey(csKey);       
    }

    /// <summary>
    /// Get record with specified Guid Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Get(Guid csKey)
    {
        return this.GetRecordByKey(csKey.ToString());
    }

    /// <summary>
    /// Get record with specified int Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Get(int csKey)
    {
        return this.GetRecordByKey(csKey.ToString());
    }

    /// <summary>
    /// Get record with specified DateTime Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    /// <exception cref="EntityDoesntExistsException"></exception>
    public T Get(DateTime csKey)
    {
        return this.GetRecordByKey(csKey.ToString());
    }
}
