using csStorage.Base.csEntityBaseModel;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    #region Properties    
    private object Entity { get; set; } = default!;

    private string csKeyValue { get; set; }

    public string StoragePath { get; set; } = default!;

#endregion

    public csContextBuilder()
	{
        CreateCsStoragePath();
    }

    private void CreateCsStoragePath()
    {
        var directoryPath = AppDomain.CurrentDomain.BaseDirectory + $"\\csStorage";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        StoragePath = directoryPath + $"\\{typeof(T).Name}.csv";
    }
}
