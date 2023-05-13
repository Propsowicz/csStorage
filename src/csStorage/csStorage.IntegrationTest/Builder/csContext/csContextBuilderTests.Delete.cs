using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.IntegrationTest.Shared;
using FluentAssertions;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{      
    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityToDelete_WhenDelete_ThenDeleteOneRecord(
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
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        contextBuilder.Delete(userEntityMock);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenStringKey_WhenDelete_ThenDeleteOneRecord(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityStringKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityStringKeyMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityStringKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        contextBuilder.Delete(userEntityMock.UserName);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenGuidKey_WhenDelete_ThenDeleteOneRecord(
        Guid username,
        int age,
        bool isAdmin,
        Guid username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityGuidKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityGuidKeyMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityGuidKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        contextBuilder.Delete(userEntityMock.csKey);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenIntKey_WhenDelete_ThenDeleteOneRecord(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityIntKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityIntKeyMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityIntKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        contextBuilder.Delete(userEntityMock.Age);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenDateTimeKey_WhenDelete_ThenDeleteOneRecord(
        string username,
        DateTime birthDay,
        bool isAdmin,
        string username2,
        DateTime birthDay2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityDateTimeKeyMock
        {
            UserName = username,
            BirthDate = birthDay,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityDateTimeKeyMock
        {
            UserName = username2,
            BirthDate = birthDay2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityDateTimeKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        contextBuilder.Delete(userEntityMock.BirthDate);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenEntityToDelete_WhenDeleteAsync_ThenDeleteOneRecord(
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
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        await contextBuilder.DeleteAsync(userEntityMock);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenStringKey_WhenDeleteAsync_ThenDeleteOneRecord(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityStringKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityStringKeyMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityStringKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        await contextBuilder.DeleteAsync(userEntityMock.UserName);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenGuidKey_WhenDeleteAsync_ThenDeleteOneRecord(
        Guid username,
        int age,
        bool isAdmin,
        Guid username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityGuidKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityGuidKeyMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityGuidKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        await contextBuilder.DeleteAsync(userEntityMock.csKey);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenIntKey_WhenDeleteAsync_ThenDeleteOneRecord(
        string username,
        int age,
        bool isAdmin,
        string username2,
        int age2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityIntKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityIntKeyMock
        {
            UserName = username2,
            Age = age2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityIntKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        await contextBuilder.DeleteAsync(userEntityMock.Age);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenDateTimeKey_WhenDeleteAsync_ThenDeleteOneRecord(
        string username,
        DateTime birthDay,
        bool isAdmin,
        string username2,
        DateTime birthDay2,
        bool isAdmin2
    )
    {
        // given
        var userEntityMock = new UserEntityDateTimeKeyMock
        {
            UserName = username,
            BirthDate = birthDay,
            IsAdmin = isAdmin
        };
        var userEntityMock2 = new UserEntityDateTimeKeyMock
        {
            UserName = username2,
            BirthDate = birthDay2,
            IsAdmin = isAdmin2
        };
        var contextBuilder = new csContextBuilder<UserEntityDateTimeKeyMock>();
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        await contextBuilder.DeleteAsync(userEntityMock.BirthDate);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        oldNumberOfEntities.Should().Be(2);
        newNumberOfEntities.Should().Be(1);
    }
}
