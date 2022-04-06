namespace Git.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 36;

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int RepositoryNameMinLength = 3;
        public const int RepositoryNameMaxLength = 10;
        public const string RepositoryPublicType = "Public";
        public const string RepositoryPrivateType = "Private";

        public const int CommitDescriptionMinLength = 5;
        public const int CommitDescriptionMaxLength = 2000;
    }
}
