using csStorage.IntegrationTest.Shared;
using csStorage.Builder.csContextBuilder;
using FluentAssertions;
using AutoFixture.Xunit2;
using csStorage.Exceptions;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{    
    [TestAfter]
    [Theory, AutoData]
    public void GivenOkEntityModel_WhenAdd_ThenCreateOneRecord(
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
        var oldNumberOfEntieties = contextBuilder.Get().Count();

        // when
        contextBuilder.Add(userEntityMock);

        // then
        var newNumberOfEntieties = contextBuilder.Get().Count();
        (newNumberOfEntieties - oldNumberOfEntieties).Should().Be(1);
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().csKey.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
        contextBuilder.Get().Last().IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenTwoEntitiesWithSameKeyModel_WhenAdd_ThenCreateOnlyOneRecord(
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
        var userEntityMock2 = new UserEntityMock
        {
            UserName = username,
            Age = age + 5,
            IsAdmin = !isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        var oldNumberOfEntieties = contextBuilder.Get().Count();
        contextBuilder.Add(userEntityMock);

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock2);
        };

        // then
        act.Should().Throw<Exception>();

        var newNumberOfEntieties = contextBuilder.Get().Count();
        (newNumberOfEntieties - oldNumberOfEntieties).Should().Be(1);
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().csKey.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
        contextBuilder.Get().Last().IsAdmin.Should().Be(isAdmin);
    }
}
