using csStorage.UnitTest.Shared;
using FluentAssertions;

namespace csStorage.UnitTest.Builder.csContext;

public partial class csContextBuilderTests
{
    [TestAfter]
    [Fact]
    public void GivenNewDirectoryPath_WhenAdd_ThenCreateNewDirectory()
    {
        // given
        // when
        var contextBuilder = new InheritedCsContextBuilder<UserEntityMock?>();

        // then
        contextBuilder.DirectoryPath.Should().Be(DirectoryPathToSet.CreatePathString());
    }
}
