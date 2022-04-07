namespace FootballManager.Controllers
{
    using FootballManager.Contracts;
    using FootballManager.ViewModels.Players;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class PlayersController : Controller
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService userPlayers)
        {
            this.players = userPlayers;
        }

        [Authorize]
        public HttpResponse All()
        {
            var allPlayers = players.GetAllPlayers();

            return View(allPlayers);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(PlayerFormViewModel player)
        {
            var errors = players.CreatePlayer(player).ToList();

            if (errors.Any() == false)
            {
                return Redirect("/Players/All");
            }

            return Error(errors);
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var error = players.AddPlayer(playerId, User.Id);

            if (string.IsNullOrEmpty(error))
            {
                return Redirect("/Players/All");
            }

            return Error(error);
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var error = players.RemovePlayer(playerId, User.Id);

            if (string.IsNullOrEmpty(error))
            {
                return Redirect("/Players/Collection");
            }

            return Error(error);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var userCollection = players.GetUserCollection(User.Id).ToList();

            return View(userCollection);
        }
    }
}
