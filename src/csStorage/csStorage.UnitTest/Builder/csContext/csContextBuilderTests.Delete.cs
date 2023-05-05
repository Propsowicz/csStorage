﻿using AutoFixture.Xunit2;
using csStorage.Builder.csContextBuilder;
using csStorage.Exceptions;
using csStorage.IntegrationTest.Shared;
using FluentAssertions;

namespace csStorage.IntegrationTest.Builder.csContext;

public partial class csContextBuilderTests
{
    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithNoCsFileCreated_WhenDelete_ThenThrowAnException(
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
        Action act = () =>
        {
            contextBuilder.Delete(userEntityMock);
        };

        // then
        act.Should().Throw<EntityDoesntExistsException>();
    }

    [TestAfter]
    [Theory, AutoData]
    public void GivenEntityWithKeyThatDoesntExists_WhenDelete_ThenThrowAnException(
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

        // when
        Action act = () =>
        {
            contextBuilder.Delete(userEntityMock2);
        };

        // then
        act.Should().Throw<EntityDoesntExistsException>();
    }    
}