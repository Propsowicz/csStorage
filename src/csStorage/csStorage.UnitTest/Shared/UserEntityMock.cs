﻿using csStorage.Base.csEntityBaseModel;
using csStorage.Shared;

namespace csStorage.UnitTest.Shared
{
    public class UserEntityMock : csEntityBaseModel<UserEntityMock>
    {
        [csKey]
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }   

    public class InvalidUserEntityMock : csEntityBaseModel<InvalidUserEntityMock>
    {
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityMockAutoKeyString : csEntityBaseModel<UserEntityMockAutoKeyString>
    {
        [csAutoKey]
        public string? Id { get; set; }

        public string? UserName { get; set; }

        public int Age { get; set; }
    }
}
