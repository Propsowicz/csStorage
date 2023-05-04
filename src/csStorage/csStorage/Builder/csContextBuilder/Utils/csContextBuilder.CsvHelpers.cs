using CsvHelper;
using System.Globalization;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    private void WriteRecords(IEnumerable<T> listOfEntieties)
    {
        using (var writer = new StreamWriter(StoragePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(listOfEntieties);
        }
    }

    private IEnumerable<T> GetRecords()
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
