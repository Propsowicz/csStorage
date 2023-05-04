using csStorage.Base.csEntityBaseModel;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    #region Properties    
    private object Entity { get; set; } = default!;

    private string csKeyValue { get; set; } = default!;

    public string StoragePath { get; set; } = default!;

    public string DirectoryPath { get; set; } = default!;

#endregion

    public csContextBuilder()
	{
        CreateCsStoragePath();
    }

    private void CreateCsStoragePath()
    {
        this.SetDirectoryPath();      
        this.SetStoragePath();
    }
}
