using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;
using CsvHelper;
using System.Globalization;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    public IEnumerable<T> Get()
    {
        return GetAllRecords();
    }

    public T Get(string csKeyValue)
    {
        var allRecords = this.Get();
        List<csEntityBaseModel<T>> baseModelList = new();

        foreach (var record in allRecords)
        {
            baseModelList.Add(record as csEntityBaseModel<T> 
                ?? throw new Exception("Couldn't convert to csEntityBaseModel"));                      
        }

        return ConvertObjectToGenericT(baseModelList.Where(x => x.csKeyValue == csKeyValue).FirstOrDefault() 
            ?? throw new EntityDoesntExistsException());            
    }

    public T Get(Guid csKeyValue)
    {
        var allRecords = this.Get();
        List<csEntityBaseModel<T>> baseModelList = new();

        foreach (var record in allRecords)
        {
            baseModelList.Add(record as csEntityBaseModel<T>
                ?? throw new Exception("Couldn't convert to csEntityBaseModel"));
        }

        return ConvertObjectToGenericT(baseModelList.Where(x => x.csKeyValue == csKeyValue.ToString()).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }

    public T Get(int csKeyValue)
    {
        var allRecords = this.Get();
        List<csEntityBaseModel<T>> baseModelList = new();

        foreach (var record in allRecords)
        {
            baseModelList.Add(record as csEntityBaseModel<T>
                ?? throw new Exception("Couldn't convert to csEntityBaseModel"));
        }

        return ConvertObjectToGenericT(baseModelList.Where(x => x.csKeyValue == csKeyValue.ToString()).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }

    private IEnumerable<T> GetAllRecords()
    {
        var result = new List<T>();
        if (File.Exists(StoragePath))
        {
            using (var reader = new StreamReader(StoragePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                result.AddRange(csv.GetRecords<T>());
            }
        }        
        return result;      
    }
}
