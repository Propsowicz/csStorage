using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;
using CsvHelper;
using System.Globalization;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    public IEnumerable<T> Get()
    {
        return this.GetAllRecords();
    }

    public T Get(string csKeyValue)
    {
        var entityBaseModelList = this.GetAllEntityBaseModelRecords();

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKeyValue == csKeyValue).FirstOrDefault() 
            ?? throw new EntityDoesntExistsException());            
    }

    public T Get(Guid csKeyValue)
    {
        var entityBaseModelList = this.GetAllEntityBaseModelRecords();

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKeyValue == csKeyValue.ToString()).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }

    public T Get(int csKeyValue)
    {
        var entityBaseModelList = this.GetAllEntityBaseModelRecords();

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKeyValue == csKeyValue.ToString()).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }

    private List<csEntityBaseModel<T>> GetAllEntityBaseModelRecords()
    {
        var allRecords = this.Get();
        List<csEntityBaseModel<T>> entityBaseModelList = new();

        foreach (var record in allRecords)
        {
            entityBaseModelList.Add(record as csEntityBaseModel<T>
                ?? throw new Exception("Couldn't convert to csEntityBaseModel"));
        }

        return entityBaseModelList;
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
