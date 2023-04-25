using csStorage.Base.csEntityBaseModel;

namespace csStorage.IntegrationTest.Shared
{
    public class UserEntityMock : csEntityBaseModel<UserEntityMock>
    {
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
