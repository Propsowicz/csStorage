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

    public class UserEntity2Mock : csEntityBaseModel<UserEntity2Mock>
    {
        [csKeyValue]
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class InvalidUserEntityMock
    {
        public string? UserName { get; set; }

        public int Age { get; set; }

        public bool IsAdmin { get; set; }
    }
}
