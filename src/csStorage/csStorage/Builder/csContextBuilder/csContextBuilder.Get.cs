using CsvHelper;
using System.Globalization;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    public IEnumerable<T> Get()
    {
        return GetAllRecords();
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
