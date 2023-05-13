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
    [Fact]
    public void GivenNullEntity_WhenAdd_ThenThrowAnException()
    {
        // given
        UserEntityMock? userEntityMock = null;
        var contextBuilder = new csContextBuilder<UserEntityMock?>();

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock!);
        };

        // then
        act.Should().Throw<Exception>();
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithoutKeyAttribute_WhenAdd_ThenThrowAnException(
        string username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new InvalidUserEntityMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<InvalidUserEntityMock>();

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock);
        };

        // then
        act.Should().Throw<CsKeyAttributeHasNotBeenSetException>();
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenInvalidEntity_WhenAdd_ThenGetFailureResult(
        string username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new InvalidUserEntityMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<InvalidUserEntityMock>();

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock);
        };

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Failure);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenValidEntity_WhenAdd_ThenGetSuccessResult(
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
        contextBuilder.Add(userEntityMock);
        
        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenValidEntity_WhenAddAsync_ThenGetSuccessResult(
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
        await contextBuilder.AddAsync(userEntityMock);

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithCsAutoKeyAttributeAndStringTypeCsAutoKey_WhenAdd_ThenThrowAnException(
        string username,
        int age
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyString
        {
            UserName = username,
            Age = age
        };
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyString>();

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock);
        };

        // then
        act.Should().Throw<CsAutoKeyNeedToBeIntOrGuidTypeException>();
    }
}
