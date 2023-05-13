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
                if (obj is csAutoKey)
                {
                    var propertyType = propertyInfo?.PropertyType;

                    if (propertyType != typeof(int) && propertyType != typeof(Guid))
                    {
                        throw new CsAutoKeyNeedToBeIntOrGuidTypeException();
                    }
                    var value = propertyInfo?.GetValue(entity);

                    if ((value!.GetType() == typeof(int) && (int)value == 0) ||
                        ((value!.GetType() == typeof(Guid) && (Guid)value! == Guid.Empty))    
                    )
                    {
                        this.SetCsAutoKeyProperties(nameof(csAutoKey), propertyType);
                    }
                    else
                    {                        
                        this.SetCsAutoKeyProperties(value.ToString()!, propertyType);                        
                    }
                }
            }
        }        

        if (string.IsNullOrEmpty(this.csKey))
        {
            throw new CsKeyAttributeHasNotBeenSetException();
        }
    }

    private void SetCsKeyWithAutoValue(IEnumerable<T> allRecords, csEntityBaseModel<T> entity)
    {
        if (this.AutoKeyType == typeof(int))
        {
            var entityBaseModelList = this.ConvertGenericListToEntityBaseModelList(allRecords);
            int maxAutoKeyValue;

            if (entityBaseModelList.Count > 0)
            {
                maxAutoKeyValue = entityBaseModelList.Max(x => Convert.ToInt32(x.csKey));
            }
            else
            {
                maxAutoKeyValue = 0;
            }

            this.csKey = (maxAutoKeyValue + 1).ToString();
        }

        if (this.AutoKeyType == typeof(Guid))
        {
            this.csKey = Guid.NewGuid().ToString();
        }

        this.SetEntity(entity);
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

    private void SetCsAutoKeyProperties(string value, Type propertyType)
    {
        this.IsAutoKey = true;
        this.AutoKeyType = propertyType;
        this.csKey = value;
    }
}
