namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Contracts;
    using SharedTrip.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService userSirvice)
        {
            users = userSirvice;
        }

        public HttpResponse Register() => User.IsAuthenticated ? Redirect("/Trips/All") : View();

        //public Response Register()
        //{
        //    if (User.IsAuthenticated)
        //    {
        //        return Redirect("/Trips/All");
        //    }

        //    return View();
        //}

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

        public HttpResponse Login() => User.IsAuthenticated ? Redirect("/Trips/All") : View();

        [HttpPost]
        public HttpResponse Login(LoginFormViewModel model)
        {
            var userId = users.GetUserId(model);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
            {
                return Error("Incorrect Username or Email.");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
