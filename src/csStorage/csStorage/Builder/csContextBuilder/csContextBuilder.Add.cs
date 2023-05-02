using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;
using csStorage.Shared;
using CsvHelper;
using System.Globalization;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    public T Add(csEntityBaseModel<T> entity)
    {
        var isEntityValid = this.IsEntityValid(entity);
        var listOfEntieties = new List<T>();
        this.SetCsKeyValue(entity);
        this.SetEntity(entity);
        
        if (File.Exists(StoragePath))
        {
            var allRecords = this.GetAllRecords();
            var isKeyUnique = this.IsKeyUnique(allRecords);
            listOfEntieties.AddRange(allRecords);

            if (isKeyUnique && isEntityValid)
            {
                listOfEntieties.Add(ConvertObjectToGenericT(this.Entity));
            }
        }
        else
        {                      
            if (isEntityValid)
            {     
                listOfEntieties.Add(ConvertObjectToGenericT(this.Entity));
            }
        }

        this.WriteRecords(listOfEntieties);

        return ConvertObjectToGenericT(this.Entity);
    }

    private void WriteRecords(IEnumerable<T> listOfEntieties)
    {
        using (var writer = new StreamWriter(StoragePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(listOfEntieties);
        }
    }

    public bool IsEntityValid(csEntityBaseModel<T> entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (!typeof(T).IsSubclassOf(typeof(csEntityBaseModel<T>)))
        {
            return true;
        }
        return true;
    }

    private T ConvertObjectToGenericT(object entity)
    {
        if (entity is T)
        {
            return (T)entity;
        }
        try
        {
            return (T)Convert.ChangeType(entity, typeof(T));
        }
        catch (InvalidCastException)
        {
            throw new CantConvertObjectToGenericClass(); 
        }
    }

    private bool IsKeyUnique(IEnumerable<T> allRecords)
    {
        var listOfcsKeyValues = new List<KeyValueModel>();
        this.FillListOfCsKeyValues(ref listOfcsKeyValues, allRecords);
        var isKeyUnique = !listOfcsKeyValues.Any(x => x.csKeyValue == this.csKeyValue);
        if (!isKeyUnique)
        {
            throw new ThisKeyValueAlreadyExists();
        }
        return isKeyUnique;
    }

    private void FillListOfCsKeyValues(
        ref List<KeyValueModel> listOfcsKeyValues, 
        IEnumerable<T> allRecords
    )
    {
        foreach (var record in allRecords)
        {
            try
            {
                foreach (var propertyInfo in record.GetType().GetProperties())
                {
                    if (propertyInfo.Name == nameof(this.csKeyValue))
                    {
                        var value = propertyInfo?.GetValue(record)?.ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            listOfcsKeyValues.Add(new KeyValueModel(value));
                        }
                    }
                }
            }
            catch { }
        }
    }

    private void SetEntity(csEntityBaseModel<T> entity)
    {
        entity.csKeyValue = this.csKeyValue;
        this.Entity = entity;
    }

    private void SetCsKeyValue(csEntityBaseModel<T> entity)
    {
        try
        {
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                foreach (var obj in propertyInfo.GetCustomAttributes(true))
                {
                    if (obj is csKeyValue)
                    {                        
                        var value = propertyInfo?.GetValue(entity)?.ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            this.csKeyValue = value;
                        }
                    }
                }
            }
        }
        catch { }        
    }       
}
