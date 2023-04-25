using CsvHelper;
using System.Globalization;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    public T Add(T entity)
    {
        Entity = entity;

        this.IsEntityValid();

        using (var writer = new StreamWriter(StoragePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) 
        {
            csv.WriteRecord(entity);
        }

        return entity;
    }
}
