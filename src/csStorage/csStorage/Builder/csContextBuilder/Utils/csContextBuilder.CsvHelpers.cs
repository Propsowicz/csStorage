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

    private async Task WriteRecordsAsync(IEnumerable<T> listOfEntieties)
    {
        using (var writer = new StreamWriter(StoragePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            await csv.WriteRecordsAsync(listOfEntieties);
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

    private async Task<IEnumerable<T>> GetRecordsAsync()
    {
        var result = new List<T>();
        if (File.Exists(StoragePath))
        {
            using (var reader = new StreamReader(StoragePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                await foreach (var record in csv.GetRecordsAsync<T>())
                {
                    result.Add(record);
                }
            }
        }
        return result;
    }
}
