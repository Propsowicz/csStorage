using csStorage.Base.csEntityBaseModel;
using csStorage.Shared;

namespace csStorage.IntegrationTest.Shared
{
    public class UserEntityMock : csEntityBaseModel<UserEntityMock>
    {
        [csKeyValue]
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityStringKeyMock : csEntityBaseModel<UserEntityStringKeyMock>
    {
        [csKeyValue]
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityGuidKeyMock : csEntityBaseModel<UserEntityGuidKeyMock>
    {
        [csKeyValue]
        public Guid? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityIntKeyMock : csEntityBaseModel<UserEntityIntKeyMock>
    {
        public string? UserName { get; set; }

        [csKeyValue]
        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class InvalidUserEntityMock : csEntityBaseModel<InvalidUserEntityMock>
    {
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }
}
