namespace FootballManager.Services
{
    using FootballManager.Contracts;
    using FootballManager.Data;
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;
    public class UserService : Repository, IUserService
    {
        private readonly IValidatorService validator;
        private readonly IPasswordHasher hashedPassword;

        public UserService(FootballManagerDbContext db,
        IValidatorService userValidator,
        IPasswordHasher passwordHasher)
            : base(db)
        {
            validator = userValidator;
            hashedPassword = passwordHasher;
        }

        public ICollection<string> CreateUser(RegisterFormViewModel model)
        {
            List<string> errors = validator.ValidateModel(model).ToList();

            if (IsUsernameAvailable(model.Username)
                || IsEmailAvailable(model.Email))
            {
                errors.Add($"User or Email exists.");
            }

            if (errors.Any())
            {
                return errors;
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword.HashPassword(model.Password),
            };

            db.Add(user);
            db.SaveChanges();

            return errors;
        }

        public string GetUserId(LoginFormViewModel model)
        {
            var password = hashedPassword.HashPassword(model.Password);

            var userId = All<User>()
                    .Where(u => u.Username == model.Username && u.Password == password)
                    .Select(u => u.Id)
                    .FirstOrDefault();

            return userId;
        }

        public bool IsEmailAvailable(string email)
        {
            return All<User>().Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return All<User>().Any(u => u.Username == username);
        }
    }
}

