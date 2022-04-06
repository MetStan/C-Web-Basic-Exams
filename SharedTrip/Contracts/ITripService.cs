using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        ICollection<string> CreateTrip(TripFormViewModel model);

        ICollection<TripViewModel> GetAllTrips();

        TripViewModel GetTripInfo (string tripId);

        string AddUserToTrip(string tripId, string userId);
    }
}
