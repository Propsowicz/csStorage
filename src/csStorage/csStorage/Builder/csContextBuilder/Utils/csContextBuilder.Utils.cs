using csStorage.Base.csEntityBaseModel;
using csStorage.Exceptions;

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
      
    private List<T> GetEntietiesToAddInAddMethod(csEntityBaseModel<T> entity)
    {
        this.SetContextBuilderProperties(entity);
        var entietiesToAdd = new List<T>();

        if (File.Exists(this.StoragePath))
        {
            var allRecords = this.GetRecords();
            this.IsKeyUnique();
            entietiesToAdd.AddRange(allRecords);
        }
        entietiesToAdd.Add(ConvertObjectToGenericT(this.Entity));

        return entietiesToAdd;
    }

    private List<T> GetEntietiesToAddInUpdateMethod(csEntityBaseModel<T> entity)
    {
        this.SetContextBuilderProperties(entity);
        var entietiesToAdd = new List<T>();

        if (File.Exists(this.StoragePath))
        {
            var allRecords = this.GetRecords();
            this.DoesKeyExists();

            var recordsWithoutUpdatedEntity = this.ConvertGenericListToEntityBaseModelList(allRecords).Where(x => x.csKey != this.csKey);
            var genericRecordsWithoutUpdatedEntity = this.ConvertEntityBaseModelListToGenericList(recordsWithoutUpdatedEntity);

            entietiesToAdd.AddRange(genericRecordsWithoutUpdatedEntity);

            entietiesToAdd.Add(ConvertObjectToGenericT(this.Entity));
        }
        else
        {
            throw new EntityDoesntExistsException();
        }

        return entietiesToAdd;
    }

    private List<T> GetEntietiesToAddInDeleteMethod(csEntityBaseModel<T>? entity)
    {
        this.SetContextBuilderProperties(entity);
        var entietiesToAdd = new List<T>();

        if (File.Exists(this.StoragePath))
        {
            var allRecords = this.GetRecords();
            this.DoesKeyExists();

            var recordsWithoutUpdatedEntity = this.ConvertGenericListToEntityBaseModelList(this.GetRecords()).Where(x => x.csKey != this.csKey);
            var genericRecordsWithoutUpdatedEntity = this.ConvertEntityBaseModelListToGenericList(recordsWithoutUpdatedEntity);

            entietiesToAdd.AddRange(genericRecordsWithoutUpdatedEntity);
        }
        else
        {
            throw new EntityDoesntExistsException();
        }

        return entietiesToAdd;
    }
}
