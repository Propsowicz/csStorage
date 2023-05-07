using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.IntegrationTest.Shared;
using FluentAssertions;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{       
    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityToUpdate_WhenUpdate_ThenUpdateOneRecord(
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
        var newAge = contextBuilder.Get(userEntityMock.UserName).Age;
        oldAge.Should().Be(age);
        newAge.Should().Be(ageToUpdate);
        contextBuilder.Get().Should().HaveCount(2);
    }

    [TestAfter]
    [Theory, AutoData]
    public async Task GivenEntityToUpdate_WhenUpdateAsync_ThenUpdateOneRecord(
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
        var newAge = contextBuilder.Get(userEntityMock.UserName).Age;
        oldAge.Should().Be(age);
        newAge.Should().Be(ageToUpdate);
        contextBuilder.Get().Should().HaveCount(2);
    }
}
