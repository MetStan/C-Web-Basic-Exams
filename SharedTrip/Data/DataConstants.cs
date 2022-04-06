namespace SharedTrip.Data
{
    public class DataConstants
    {
        //User constants
        public const int IdMaxLength = 36;

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;
        public const int HashedPasswordMaxLength = 64;


        public const int EmailMaxLength = 200;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string InvalidEmailMessage = "Email not valid.";
        //Trip constants
        public const int PointNameMaxLength = 100;

        public const int SeatsMinValue = 2;
        public const int SeatsMaxValue = 6;

        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 1000;

        public const int PictureUrlMaxLength = 2048;
    }
}
