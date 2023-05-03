using csStorage.Builder.csContextBuilder;
using System.Diagnostics;
using System.Reflection;
using Xunit.Sdk;

namespace csStorage.IntegrationTest.Shared;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class TestAfter : BeforeAfterTestAttribute
{
    public override void After(MethodInfo methodUnderTest)
    {
        var directoryPath = new csContextBuilder<UserEntityMock>().DirectoryPath;

        if (Directory.Exists(directoryPath))
        {
            Directory.Delete(directoryPath, true);
        }
    }
}
