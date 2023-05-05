using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.Exceptions;
using csStorage.IntegrationTest.Shared;
using FluentAssertions;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{
    [TestAfter]
    [Fact]
    public void GivenNullEntityModel_WhenAdd_ThenThrowAnException()
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
    public void GivenEntityModelWithoutKeyAttribute_WhenAdd_ThenThrowAnException(
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
}
