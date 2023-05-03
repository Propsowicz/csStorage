using csStorage.Base.csEntityBaseModel;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    #region Properties    
    private object Entity { get; set; } = default!;

    private string csKeyValue { get; set; }

    public string StoragePath { get; set; } = default!;

    public string DirectoryPath { get; set; } = default!;

#endregion

    public csContextBuilder()
	{
        CreateCsStoragePath();
    }

    private void CreateCsStoragePath()
    {
        this.DirectoryPath = AppDomain.CurrentDomain.BaseDirectory + $"\\csStorage";

        if (!Directory.Exists(this.DirectoryPath))
        {
            Directory.CreateDirectory(this.DirectoryPath);
        }

        this.StoragePath = this.DirectoryPath + $"\\{typeof(T).Name}.csv";
    }
}
