using csStorage.Shared;

namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
#region Properties    
    private string csKey { get; set; } = default!;

    private object Entity { get; set; } = default!;

    private bool IsAutoKey { get; set; } = false;

    private Type AutoKeyType { get; set; } = null!;

    public string StoragePath { get; private set; } = default!;

    public string DirectoryPath { get; protected set; } = default!;

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
