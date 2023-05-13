using System.Xml.Linq;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    /// <summary>
    /// Get all records from csv file.
    /// </summary>
    /// <returns>IEnumerable<Entities></returns>
    public IEnumerable<T> Get()
    {
        var records = this.GetRecords();
        this.SetSuccessResult();
        return records;
    }

    /// <summary>
    /// Get record with specified string Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public T Get(string csKey)
    {
        return this.GetRecordByKey(csKey);       
    }

    /// <summary>
    /// Get record with specified Guid Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public T Get(Guid csKey)
    {
        return this.GetRecordByKey(csKey.ToString());
    }

    /// <summary>
    /// Get record with specified int Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public T Get(int csKey)
    {
        return this.GetRecordByKey(csKey.ToString());
    }

    /// <summary>
    /// Get record with specified DateTime Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public T Get(DateTime csKey)
    {
        return this.GetRecordByKey(csKey.ToString());
    }

    /// <summary>
    /// Asynchronously get all records from csv file.
    /// </summary>
    /// <returns>IEnumerable<Entities></returns>
    public async Task<IEnumerable<T>> GetAsync()
    {
        var records = await this.GetRecordsAsync();
        this.SetSuccessResult();
        return records;
    }

    /// <summary>
    /// Asynchronously get record with specified string Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public async Task<T> GetAsync(string csKey)
    {
        return await this.GetRecordByKeyAsync(csKey);
    }

    /// <summary>
    /// Asynchronously get record with specified Guid Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public async Task<T> GetAsync(Guid csKey)
    {
        return await this.GetRecordByKeyAsync(csKey.ToString());
    }

    /// <summary>
    /// Asynchronously get record with specified int Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public async Task<T> GetAsync(int csKey)
    {
        return await this.GetRecordByKeyAsync(csKey.ToString());
    }

    /// <summary>
    /// Asynchronously get record with specified DateTime Key.
    /// </summary>
    /// <param name="csKey"></param>
    /// <returns>Entity</returns>
    public async Task<T> GetAsync(DateTime csKey)
    {
        return await this.GetRecordByKeyAsync(csKey.ToString());
    }
}
