using csStorage.IntegrationTest.Shared;
using csStorage.Builder.csContextBuilder;
using FluentAssertions;
using AutoFixture.Xunit2;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{
    [Theory, AutoData]
    public void GivenNotInheritedEntityModel_WhenAdd_ThenThrowException(
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
        act.Should().Throw<Exception>();
    }

    [Fact]
    public void GivenNullEntityModel_WhenAdd_ThenThrowException()
    {
        // given
        UserEntityMock? userEntityMock = null;
        var contextBuilder = new csContextBuilder<UserEntityMock?>();

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock);
        };

        // then
        act.Should().Throw<Exception>();
    }

    [Theory, AutoData]
    public void GivenOkEntityMoel_WhenAdd_ThenThrowException(
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
        
    }
}
