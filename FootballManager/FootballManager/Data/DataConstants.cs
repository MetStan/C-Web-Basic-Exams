namespace FootballManager.Data
{
    public class DataConstants
    {
        //User constants
        public const int IdMaxLength = 36;

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;
        public const int HashedPasswordMaxLength = 64;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string InvalidEmailMessage = "Email not valid.";
        
        //Player constants
        public const int FullNameMaxLength = 80;
        public const int FullNameMinLength = 5;

        public const int PositionNameMaxLength = 20;
        public const int PositionNameMinLength = 5;

        public const int EnduranceMinValue = 0;
        public const int EnduranceMaxValue = 10;

        public const int SpeedMinValue = 0;
        public const int SpeedMaxValue = 10;

        public const int DescriptionMaxLength = 200;

        public const int PictureUrlMaxLength = 2048;
    }
}
