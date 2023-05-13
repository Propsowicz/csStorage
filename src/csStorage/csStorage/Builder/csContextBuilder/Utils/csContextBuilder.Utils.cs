using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;
using csStorage.Shared;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    private T GetRecordByKey(string csKey)
    {
        var entityBaseModelList = this.ConvertGenericListToEntityBaseModelList(this.GetRecords());

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKey == csKey).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }

    private async Task<T> GetRecordByKeyAsync(string csKey)
    {
        var entityBaseModelList = this.ConvertGenericListToEntityBaseModelList(await this.GetRecordsAsync());

        return this.ConvertObjectToGenericT(entityBaseModelList.Where(x => x.csKey == csKey).FirstOrDefault()
            ?? throw new EntityDoesntExistsException());
    }
      
    private List<T> GetEntitiesToAddInAddMethod(csEntityBaseModel<T> entity)
    {
        this.SetContextBuilderProperties(entity);
        var allRecords = this.GetRecords();

        if (this.IsAutoKey && this.csKey == nameof(csAutoKey))
        {
            this.SetCsKeyWithAutoValue(allRecords, entity);
        }

        var entitiesToAdd = new List<T>();

        if (File.Exists(this.StoragePath))
        {                        
            this.IsKeyUnique();           
            entitiesToAdd.AddRange(allRecords);
        }

        entitiesToAdd.Add(ConvertObjectToGenericT(this.Entity));

        return entitiesToAdd;
    }

    private List<T> GetEntitiesToAddInUpdateMethod(csEntityBaseModel<T> entity)
    {
        this.SetContextBuilderProperties(entity);
        var entitiesToAdd = new List<T>();

        if (File.Exists(this.StoragePath))
        {
            var allRecords = this.GetRecords();
            this.DoesKeyExists();

            var recordsWithoutUpdatedEntity = this.ConvertGenericListToEntityBaseModelList(allRecords).Where(x => x.csKey != this.csKey);
            var genericRecordsWithoutUpdatedEntity = this.ConvertEntityBaseModelListToGenericList(recordsWithoutUpdatedEntity);

            entitiesToAdd.AddRange(genericRecordsWithoutUpdatedEntity);

            entitiesToAdd.Add(ConvertObjectToGenericT(this.Entity));
        }
        else
        {
            throw new EntityDoesntExistsException();
        }

        return entitiesToAdd;
    }

    private List<T> GetEntitiesToAddInDeleteMethod(csEntityBaseModel<T>? entity)
    {
        this.SetContextBuilderProperties(entity);

        var entitiesToAdd = new List<T>();
        if (File.Exists(this.StoragePath))
        {
            var allRecords = this.GetRecords();
            this.DoesKeyExists();

            var recordsWithoutUpdatedEntity = this.ConvertGenericListToEntityBaseModelList(this.GetRecords()).Where(x => x.csKey != this.csKey);
            var genericRecordsWithoutUpdatedEntity = this.ConvertEntityBaseModelListToGenericList(recordsWithoutUpdatedEntity);

            entitiesToAdd.AddRange(genericRecordsWithoutUpdatedEntity);
        }
        else
        {
            throw new EntityDoesntExistsException();
        }

        return entitiesToAdd;
    }
}
