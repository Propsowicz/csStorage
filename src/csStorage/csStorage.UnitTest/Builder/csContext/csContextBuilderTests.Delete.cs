using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.Exceptions;
using csStorage.IntegrationTest.Shared;
using csStorage.UnitTest.Shared;
using FluentAssertions;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{
    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithNoCsFileCreated_WhenDelete_ThenThrowAnException(
        string username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityMock>();

        // when
        Action act = () =>
        {
            contextBuilder.Delete(userEntityMock);
        };

        // then
        act.Should().Throw<EntityDoesntExistsException>();
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithKeyThatDoesntExists_WhenDelete_ThenThrowAnException(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        contextBuilder.Add(userEntityMock);

        // when
        Action act = () =>
        {
            contextBuilder.Delete(userEntityMock2);
        };

        // then
        act.Should().Throw<EntityDoesntExistsException>();
    }

    [TestAfter]
    [Fact]
    public void GivenNotExistingKey_WhenDelete_ThenThrowAnException()
    {
        // given        
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        string usernameMock = "test";

        // when
        Action act = () =>
        {
            contextBuilder.Delete(usernameMock);
        };

        // then        
        act.Should().Throw<EntityDoesntExistsException>();
    }

    [TestAfter]
    [Fact]
    public void GivenNotExistingKey_WhenDelete_ThenGetFailureResult()
    {
        // given        
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        string usernameMock = "test";

        // when
        Action act = () =>
        {
            contextBuilder.Delete(usernameMock);
        };

        // then        
        contextBuilder.Result.Should().Be(ContextBuilderResult.Failure);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityToDelete_WhenDelete_ThenGetSuccessResult(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);

        // when
        contextBuilder.Delete(userEntityMock);

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenEntityToDelete_WhenDeleteAsync_ThenGetSuccessResult(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);

        // when
        await contextBuilder.DeleteAsync(userEntityMock);

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }
}
