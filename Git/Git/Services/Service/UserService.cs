using Git.Data;
using Git.Data.Models;
using Git.Services.Contracts;
using Git.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class UserService : DBaseService<User>, IUserService
    {
        private readonly IValidatorService validator;
        private readonly IPasswordHasher hashedPassword;

        public UserService(ApplicationDbContext db,
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
                errors.Add($"User or Email exists already.");
            }

            if (errors.Any())
            {
                return errors;
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword.HashPassword(model.Password)
            };

            db.Users.Add(user);
            db.SaveChanges();

            return errors;
        }

        public string GetUserId(LoginFormViewModel model)
        {
            var password = hashedPassword.HashPassword(model.Password);

            var userId = db.Users.Where(u => u.Username == model.Username && u.Password == password)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public bool IsEmailAvailable(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return db.Users.Any(u => u.Username == username);
        }
    }
}
