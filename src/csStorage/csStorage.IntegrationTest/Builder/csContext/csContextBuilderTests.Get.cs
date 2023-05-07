using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.IntegrationTest.Shared;
using FluentAssertions;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{
    [TestAfter]
    [Theory, AutoData]
    public void GivenNoKey_WhenGet_ThenGetListOfAllRecords(
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
        listOfUsers.Should().NotBeNullOrEmpty();
        listOfUsers.Count().Should().Be(2);
        listOfUsers[0].UserName.Should().Be(username);
        listOfUsers[1].UserName.Should().Be(username2);
    }

    [TestAfter]
    [Fact]
    public void GivenNoKeyAndEmptyCsvFile_WhenGet_ThenGetEmptyList()
    {
        // given        
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        
        // when
        var listOfUsers = contextBuilder.Get().ToList();

        // then
        listOfUsers.Should().BeEmpty();
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenStringKey_WhenGet_ThenGetRecord(
        string username,
        int age,
        bool isAdmin        
    )
    {
        // given
        var userEntityMock = new UserEntityStringKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };        
        var contextBuilder = new csContextBuilder<UserEntityStringKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = contextBuilder.Get(username);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.Age.Should().Be(age);
        userEntity.IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenGuidKey_WhenGet_ThenGetRecord(
        Guid username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityGuidKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityGuidKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = contextBuilder.Get(username);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.Age.Should().Be(age);
        userEntity.IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenIntKey_WhenGet_ThenGetRecord(
        string username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityIntKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityIntKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = contextBuilder.Get(age);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.Age.Should().Be(age);
        userEntity.IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenDateTimeKey_WhenGet_ThenGetRecord(
        string username,
        DateTime birthDate,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityDateTimeKeyMock
        {
            UserName = username,
            BirthDate = birthDate,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityDateTimeKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = contextBuilder.Get(birthDate);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.BirthDate.Should().BeCloseTo(birthDate, TimeSpan.FromSeconds(1));
        userEntity.IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenNoKey_WhenGetAsync_ThenGetListOfAllRecords(
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
        var listOfUsers = listOfUsersAsync.ToList();

        // then
        listOfUsers.Should().NotBeNullOrEmpty();
        listOfUsers.Count().Should().Be(2);
        listOfUsers[0].UserName.Should().Be(username);
        listOfUsers[1].UserName.Should().Be(username2);
    }

    [TestAfter]
    [Fact]
    public async Task GivenNoKeyAndEmptyCsvFile_WhenGetAsync_ThenGetEmptyList()
    {
        // given        
        var contextBuilder = new csContextBuilder<UserEntityMock>();

        // when
        var listOfUsersAsync = await contextBuilder.GetAsync();
        var listOfUsers = listOfUsersAsync.ToList();

        // then
        listOfUsers.Should().BeEmpty();
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenStringKey_WhenGetAsync_ThenGetRecord(
        string username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityStringKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityStringKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = await contextBuilder.GetAsync(username);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.Age.Should().Be(age);
        userEntity.IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenGuidKey_WhenGetAsync_ThenGetRecord(
        Guid username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityGuidKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityGuidKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = await contextBuilder.GetAsync(username);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.Age.Should().Be(age);
        userEntity.IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenIntKey_WhenGetAsync_ThenGetRecord(
        string username,
        int age,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityIntKeyMock
        {
            UserName = username,
            Age = age,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityIntKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = await contextBuilder.GetAsync(age);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.Age.Should().Be(age);
        userEntity.IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenDateTimeKey_WhenGetAsync_ThenGetRecord(
        string username,
        DateTime birthDate,
        bool isAdmin
    )
    {
        // given
        var userEntityMock = new UserEntityDateTimeKeyMock
        {
            UserName = username,
            BirthDate = birthDate,
            IsAdmin = isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityDateTimeKeyMock>();
        contextBuilder.Add(userEntityMock);

        // when
        var userEntity = await contextBuilder.GetAsync(birthDate);

        // then
        userEntity.Should().NotBeNull();
        userEntity.UserName.Should().Be(username);
        userEntity.BirthDate.Should().BeCloseTo(birthDate, TimeSpan.FromSeconds(1));
        userEntity.IsAdmin.Should().Be(isAdmin);
    }
}
