using csStorage.Builder.csContextBuilder;

namespace csStorage.UnitTest.Shared;

public static class DirectoryPathToSet
{
    public static string CreatePathString()
    {
        var appDomainDir = AppDomain.CurrentDomain.BaseDirectory;

        return Path.GetFullPath(Path.Combine(appDomainDir, @"..\..\..\csvFiles\"));
    }
}

public class InheritedCsContextBuilder<T> : csContextBuilder<T>
{
    protected override void SetDirectoryPath()
    {
        this.DirectoryPath = DirectoryPathToSet.CreatePathString();
    }
}
