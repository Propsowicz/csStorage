using csStorage.Shared;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    #region Properties    
    private string csKey { get; set; } = default!;

    private object Entity { get; set; } = default!;

    public string StoragePath { get; set; } = default!;

    public string DirectoryPath { get; set; } = default!;

    public string Result { get; private set; } = ResultStatus.Failure;

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
