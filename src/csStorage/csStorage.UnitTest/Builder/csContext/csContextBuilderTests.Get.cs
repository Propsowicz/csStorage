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
    public void GivenNotExistingKey_WhenGet_ThenThrowAnException()
    {
        // given        
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        string usernameMock = "test";

        // when
        Action act = () =>
        {
            var listOfUsers = contextBuilder.Get(usernameMock);
        };

        // then        
        act.Should().Throw<EntityDoesntExistsException>();
    }

    [TestAfter]
    [Fact]
    public void GivenNotExistingKey_WhenGet_ThenGetFailureResult()
    {
        // given        
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        string usernameMock = "test";

        // when
        Action act = () =>
        {
            var listOfUsers = contextBuilder.Get(usernameMock);
        };

        // then        
        contextBuilder.Result.Should().Be(ContextBuilderResult.Failure);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenNoKey_WhenGet_ThenGetSuccessResult(
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
        var listOfUsers = contextBuilder.Get().ToList();

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenNoKey_WhenGetAsync_ThenGetSuccessResult(
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
        var listOfUsersAsync = await contextBuilder.GetAsync();

        // then
        contextBuilder.Result.Should().Be(ContextBuilderResult.Success);
    }
}
