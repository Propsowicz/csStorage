﻿using csStorage.Builder.csContextBuilder;
using System.Reflection;
using Xunit.Sdk;

namespace csStorage.UnitTest.Shared;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class TestAfter : BeforeAfterTestAttribute
{
    public override void After(MethodInfo methodUnderTest)
    {
        var directoryPath = new csContextBuilder<UserEntityMock>().DirectoryPath;
        var inheritedDirectoryPath = new InheritedCsContextBuilder<UserEntityMock>().DirectoryPath;

        if (Directory.Exists(directoryPath) && Directory.Exists(inheritedDirectoryPath))
        {
            Directory.Delete(directoryPath, true);
            Directory.Delete(inheritedDirectoryPath, true);
        }
    }
}
