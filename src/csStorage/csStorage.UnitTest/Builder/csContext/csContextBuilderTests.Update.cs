using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.Exceptions;
using csStorage.UnitTest.Shared;
using FluentAssertions;

namespace csStorage.UnitTest.Builder.csContext;

public partial class csContextBuilderTests
{
    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithNoCsFileCreated_WhenUpdate_ThenThrowAnException(
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
            contextBuilder.Update(userEntityMock);
        };

        // then
        act.Should().Throw<EntityDoesntExistsException>();
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithKeyThatDoesntExists_WhenUpdate_ThenThrowAnException(
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
            contextBuilder.Update(userEntityMock2);
        };

        // then
        act.Should().Throw<EntityDoesntExistsException>();
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithNoCsFileCreated_WhenUpdate_ThenGetFailureResult(
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
            contextBuilder.Update(userEntityMock);
        };

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Failure);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityToUpdate_WhenUpdate_ThenGetSuccessResult(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2,
        int ageToUpdate
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
        var oldAge = contextBuilder.Get(userEntityMock.UserName).Age;

        // when
        userEntityMock.Age = ageToUpdate;
        contextBuilder.Update(userEntityMock);

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenEntityToUpdate_WhenUpdateAsync_ThenGetSuccessResult(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2,
        int ageToUpdate
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
        var oldAge = contextBuilder.Get(userEntityMock.UserName).Age;

        // when
        userEntityMock.Age = ageToUpdate;
        await contextBuilder.UpdateAsync(userEntityMock);

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }
}
