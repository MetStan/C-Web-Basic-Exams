
namespace FootballManager.Controllers
{
    using FootballManager.Contracts;
    using FootballManager.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService userSirvice)
        {
            users = userSirvice;
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormViewModel model)
        {
            List<string> errors = users.CreateUser(model).ToList();

            if (errors.Any() == false)
            {
                return Redirect("/Users/Login");
            }

            return Error(errors);
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormViewModel model)
        {
            var userId = users.GetUserId(model);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
            {
                return Error("Incorrect Username or Email.");
            }

            this.SignIn(userId);

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
