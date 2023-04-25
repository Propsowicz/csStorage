namespace csStorage.Builder.csContextBuilder;

public partial class csContextBuilder<T>
{
    private T Entity { get; set; } = default!;

    public string StoragePath { get; set; } = default!;

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
