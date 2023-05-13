using csStorage.Base.csEntityBaseModel;
using csStorage.Shared;

namespace csStorage.IntegrationTest.Shared
{
    public class UserEntityMock : csEntityBaseModel<UserEntityMock>
    {
        [csKey]
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityStringKeyMock : csEntityBaseModel<UserEntityStringKeyMock>
    {
        [csKey]
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityGuidKeyMock : csEntityBaseModel<UserEntityGuidKeyMock>
    {
        [csKey]
        public Guid? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityIntKeyMock : csEntityBaseModel<UserEntityIntKeyMock>
    {
        public string? UserName { get; set; }

        [csKey]
        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityDateTimeKeyMock : csEntityBaseModel<UserEntityDateTimeKeyMock>
    {
        public string? UserName { get; set; }

        [csKey]
        public DateTime BirthDate { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class InvalidUserEntityMock : csEntityBaseModel<InvalidUserEntityMock>
    {
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class UserEntityMockAutoKeyInt : csEntityBaseModel<UserEntityMockAutoKeyInt>
    {
        [csAutoKey]
        public int Id { get; set; }

        public string? UserName { get; set; }

        public int Age { get; set; }
    }

    public class UserEntityMockAutoKeyGuid : csEntityBaseModel<UserEntityMockAutoKeyGuid>
    {
        [csAutoKey]
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public int Age { get; set; }
    }
}
