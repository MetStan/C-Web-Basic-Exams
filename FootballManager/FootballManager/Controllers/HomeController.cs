namespace FootballManager.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return this.View();
        }
    }
}
