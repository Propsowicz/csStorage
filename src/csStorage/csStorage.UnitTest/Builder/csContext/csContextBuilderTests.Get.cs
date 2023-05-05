using csStorage.Builder.csContextBuilder;
using csStorage.Exceptions;
using csStorage.IntegrationTest.Shared;
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
}
