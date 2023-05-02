using csStorage.IntegrationTest.Shared;
using csStorage.Builder.csContextBuilder;
using FluentAssertions;
using AutoFixture.Xunit2;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{
    //[Theory, AutoData]
    //public void GivenNotInheritedEntityModel_WhenAdd_ThenThrowAnException(
    //    string username,
    //    int age,
    //    bool isAdmin
    //)
    //{
    //    // given
    //    var userEntityMock = new InvalidUserEntityMock
    //    {
    //        UserName = username,
    //        Age = age,
    //        IsAdmin = isAdmin
    //    };
    //    var contextBuilder = new csContextBuilder<InvalidUserEntityMock>();

    //    // when
    //    Action act = () =>
    //    {
    //        contextBuilder.Add(userEntityMock);
    //    };

    //    // then
    //    act.Should().Throw<Exception>();
    //}

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
        contextBuilder.Get().Last().csKeyValue.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
        contextBuilder.Get().Last().IsAdmin.Should().Be(isAdmin);
    }

    [Theory, AutoData]
    public void GivenTwoEntitiesWithSameKeyModel_WhenAdd_ThenCreateOnlyOneRecord(
        string username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntity2Mock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntity2Mock
        {
            UserName = username,
            Age = age + 5,
            IsAdmin = !isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntity2Mock>();
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
        contextBuilder.Get().Last().csKeyValue.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
        contextBuilder.Get().Last().IsAdmin.Should().Be(isAdmin);
    }
}
