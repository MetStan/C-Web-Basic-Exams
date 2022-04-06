﻿namespace SharedTrip.Contracts
{
    using SharedTrip.ViewModels.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        ICollection<string> CreateUser(RegisterFormViewModel model);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        string GetUserId(LoginFormViewModel model);
    }
}
