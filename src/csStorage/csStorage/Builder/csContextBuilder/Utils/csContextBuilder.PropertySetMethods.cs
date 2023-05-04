using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;
using csStorage.Shared;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{    private void SetEntity(csEntityBaseModel<T> entity)
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

        if (string.IsNullOrEmpty(this.csKeyValue))
        {
            throw new CsKeyValueAttributeHasNotBeenSetException();
        }
    }

    private void SetDirectoryPath()
    {
        this.DirectoryPath = AppDomain.CurrentDomain.BaseDirectory + $"\\csStorage";

        if (!Directory.Exists(this.DirectoryPath))
        {
            Directory.CreateDirectory(this.DirectoryPath);
        }
    }

    private void SetStoragePath()
    {
        this.StoragePath = this.DirectoryPath + $"\\{typeof(T).Name}.csv";
    }
}
