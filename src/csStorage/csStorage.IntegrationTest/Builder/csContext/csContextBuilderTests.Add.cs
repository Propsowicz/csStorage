using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.IntegrationTest.Shared;
using FluentAssertions;

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
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        contextBuilder.Add(userEntityMock);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        (newNumberOfEntities - oldNumberOfEntities).Should().Be(1);
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
        var oldNumberOfEntities = contextBuilder.Get().Count();
        contextBuilder.Add(userEntityMock);

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock2);
        };

        // then
        act.Should().Throw<Exception>();

        var newNumberOfEntities = contextBuilder.Get().Count();
        (newNumberOfEntities - oldNumberOfEntities).Should().Be(1);
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().csKey.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
        contextBuilder.Get().Last().IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenOkEntityModel_WhenAddAsync_ThenCreateOneRecord(
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
        var oldNumberOfEntities = contextBuilder.Get().Count();

        // when
        await contextBuilder.AddAsync(userEntityMock);

        // then
        var newNumberOfEntities = contextBuilder.Get().Count();
        (newNumberOfEntities - oldNumberOfEntities).Should().Be(1);
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().csKey.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
        contextBuilder.Get().Last().IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenTwoEntitiesWithSameKeyModel_WhenAddAsync_ThenCreateOnlyOneRecord(
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
            Age = age + new Random().Next(),
            IsAdmin = !isAdmin
        };
        var contextBuilder = new csContextBuilder<UserEntityMock>();
        var oldNumberOfEntities = contextBuilder.Get().Count();
        await contextBuilder.AddAsync(userEntityMock);

        // when
        Action act = () =>
        {
            contextBuilder.Add(userEntityMock2);
        };

        // then
        act.Should().Throw<Exception>();

        var newNumberOfEntities = contextBuilder.Get().Count();
        (newNumberOfEntities - oldNumberOfEntities).Should().Be(1);
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().csKey.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
        contextBuilder.Get().Last().IsAdmin.Should().Be(isAdmin);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithCsAutoKeyIntegerTypeAndEmptyValue_WhenAdd_ThenCsKeyShouldBeOne(
        string username,
        int age
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyInt
        {
            UserName = username,
            Age = age
        };        
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyInt>();

        // when        
        contextBuilder.Add(userEntityMock);
        
        // then        
        contextBuilder.Get().Last().csKey.Should().Be(1.ToString());
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenTwoEntitesWithCsAutoKeyIntegerTypeAndEmptyValue_WhenAdd_ThenFirstCsKeyShouldBeOneAndSecondShouldBeTwo(
        string username,
        int age,
        string username2,
        int age2
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyInt
        {
            UserName = username,
            Age = age
        };
        var userEntityMock2 = new UserEntityMockAutoKeyInt
        {
            UserName = username2,
            Age = age2
        };
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyInt>();

        // when        
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);

        // then        
        contextBuilder.Get(1).csKey.Should().Be(1.ToString());
        contextBuilder.Get(1).UserName.Should().Be(username);
        contextBuilder.Get(1).Age.Should().Be(age);
        contextBuilder.Get(2).csKey.Should().Be(2.ToString());
        contextBuilder.Get(2).UserName.Should().Be(username2);
        contextBuilder.Get(2).Age.Should().Be(age2);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenThreeEntitesWithCsAutoKeyIntegerTypeAndDiffValues_WhenAdd_ThenSecondCsKeyShouldBeFirstAvaibleNumber(
        string username,
        int age,
        string username2,
        int age2,
        string username3,
        int age3
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyInt
        {
            UserName = username,
            Age = age
        };
        var userEntityMock2 = new UserEntityMockAutoKeyInt
        {
            Id = 5,
            UserName = username2,
            Age = age2
        };
        var userEntityMock3 = new UserEntityMockAutoKeyInt
        {
            UserName = username3,
            Age = age3
        };
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyInt>();

        // when        
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        contextBuilder.Add(userEntityMock3);

        // then      
        contextBuilder.Get(1).csKey.Should().Be(1.ToString());
        contextBuilder.Get(2).csKey.Should().Be(2.ToString());
        contextBuilder.Get(5).csKey.Should().Be(5.ToString());
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenFourEntitesWithCsAutoKeyIntegerTypeAndEmptyDiffValues_WhenAdd_ThenListOfIdsShouldBeRight(
        string username,
        int age
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyInt
        {
            UserName = username,
            Age = age
        };
        var userEntityMock2 = new UserEntityMockAutoKeyInt
        {
            Id = 3,
            UserName = username,
            Age = age
        };
        var userEntityMock3 = new UserEntityMockAutoKeyInt
        {
            UserName = username,
            Age = age
        };
        var userEntityMock4 = new UserEntityMockAutoKeyInt
        {
            UserName = username,
            Age = age
        };
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyInt>();

        // when        
        contextBuilder.Add(userEntityMock);
        contextBuilder.Add(userEntityMock2);
        contextBuilder.Add(userEntityMock3);
        contextBuilder.Add(userEntityMock4);

        // then      
        var listOfIds = contextBuilder.Get().Select(x => Convert.ToInt32(x.csKey)).ToList();
        listOfIds.Should().HaveCount(4);
        listOfIds.Should().Contain(1);
        listOfIds.Should().Contain(2);
        listOfIds.Should().Contain(3);
        listOfIds.Should().Contain(4);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithCsAutoKeyIntegerTypeAndValue_WhenAdd_ThenCsKeyShouldBeValue(
        int id,
        string username,
        int age
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyInt
        {
            Id = id,
            UserName = username,
            Age = age
        };
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyInt>();

        // when        
        contextBuilder.Add(userEntityMock);

        // then        
        contextBuilder.Get().Last().csKey.Should().Be(id.ToString());
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithCsAutoKeyGuidTypeAndEmptyValue_WhenAdd_ThenCsKeyShouldBeGuid(
        string username,
        int age
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyGuid
        {
            UserName = username,
            Age = age
        };
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyGuid>();

        // when        
        contextBuilder.Add(userEntityMock);

        // then        
        contextBuilder.Get().Last().csKey.Length.Should().Be(36);
        contextBuilder.Get().Last().csKey.Should().NotBe(Guid.Empty.ToString());
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
    }    

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithCsAutoKeyGuidTypeAndValue_WhenAdd_ThenCsKeyShouldBeValue(
        Guid id,
        string username,
        int age
    )
    {
        // given
        var userEntityMock = new UserEntityMockAutoKeyGuid
        {
            Id = id,
            UserName = username,
            Age = age
        };
        var contextBuilder = new csContextBuilder<UserEntityMockAutoKeyGuid>();

        // when        
        contextBuilder.Add(userEntityMock);

        // then        
        contextBuilder.Get().Last().csKey.Should().Be(id.ToString());
        contextBuilder.Get().Last().UserName.Should().Be(username);
        contextBuilder.Get().Last().Age.Should().Be(age);
    }
}
