
namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Contracts;
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly ITripService trips;

        public TripsController(ITripService tripService)
        {
            this.trips = tripService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var allTrips = trips.GetAllTrips();

            return View(allTrips);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripFormViewModel trip)
        {
            List<string> errors = trips.CreateTrip(trip).ToList();

            if (errors.Any() == false)
            {
                return Redirect("/Trips/All");
            }

            return Error(errors);
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var details = trips.GetTripInfo(tripId);

            return View(details);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var error = trips.AddUserToTrip(tripId, User.Id);

            if (string.IsNullOrEmpty(error))
            {
                return Redirect("/Trips/All");
            }

            return Error(error);
            //return Redirect($"/Trips/Details?tripId={tripId}");
        }
    }
}
