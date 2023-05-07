using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;
using csStorage.Shared;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{    private void SetEntity(csEntityBaseModel<T> entity)
    {
        entity.csKey = this.csKey;
        this.Entity = entity;
    }

    private void SetCsKey(csEntityBaseModel<T> entity)
    {
        try
        {
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                foreach (var obj in propertyInfo.GetCustomAttributes(true))
                {
                    if (obj is csKey)
                    {
                        var value = propertyInfo?.GetValue(entity)?.ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            this.csKey = value;
                        }
                    }
                }
            }
        }
        catch { }

        if (string.IsNullOrEmpty(this.csKey))
        {
            throw new CsKeyAttributeHasNotBeenSetException();
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

    private void SetContextBuilderProperties(csEntityBaseModel<T>? entity)
    {
        this.IsEntityValid(entity);
        this.SetCsKey(entity!);
        this.SetEntity(entity!);
    }

    private void SetSuccessResult()
    {
        this.Result = ResultStatus.Success;
    }
}
