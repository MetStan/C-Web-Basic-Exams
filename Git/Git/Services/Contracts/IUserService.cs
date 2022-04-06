using Git.ViewModels.Users;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IUserService
    {
        ICollection<string> CreateUser(RegisterFormViewModel model);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        string GetUserId(LoginFormViewModel model);

    }
}
