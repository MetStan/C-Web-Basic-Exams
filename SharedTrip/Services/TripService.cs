namespace SharedTrip.Services
{
    using SharedTrip.Contracts;
    using SharedTrip.Data;
    using SharedTrip.Data.Common;
    using SharedTrip.Data.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripService : Repository, ITripService
    {
        private readonly IValidatorService validator;

        public TripService(ShareTripDbContext db,
            IValidatorService tripValidator) 
            : base(db)
        {
            validator = tripValidator;
        }

        public string AddUserToTrip(string tripId, string userId)
        {
            var error = string.Empty;

            var trip = All<Trip>().FirstOrDefault(t => t.Id == tripId);
            var user = All<User>().FirstOrDefault(u => u.Id == userId);

            if (trip == null || user == null)
            {
                return error = "User or trip not found!";
            }

            var IsUserInTrip = All<UserTrip>().Any(u => u.UserId == userId && u.TripId == tripId);

            if (IsUserInTrip)
            {
                return error = "User has joined to this trip already!";
            }

            if (trip.Seats == 0)
            {
                return error = "No available seats in this trip!";
            }

            trip.Seats -= 1;

            var UserTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            db.Add(UserTrip);
            db.SaveChanges();

            return error;
        }

        public ICollection<string> CreateTrip(TripFormViewModel model)
        {
            var errors = validator.ValidateModel(model).ToList();

            DateTime validDate;
            var IsdateValid = DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);

            if (IsdateValid == false)
            {
                errors.Add($"Departure Time is not valid.");
            }

            if (errors.Any())
            {
                return errors;
            }

            var trip = new Trip
            {
                Description = model.Description,
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                DepartureTime = validDate,
            };

            db.Add(trip);
            db.SaveChanges();

            return errors;
        }

        public ICollection<TripViewModel> GetAllTrips()
        {
            //var tripsQuery = All<Trip>().AsQueryable();
            var tripsQuery = All<Trip>();

            var trips = tripsQuery
                .OrderBy(dt => dt.DepartureTime)
                .Select(t => new TripViewModel
                {
                    TripId = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = t.Seats
                })
                .ToList();

            return trips;
        }

        public TripViewModel GetTripInfo(string tripId)
        {
            var tripsQuery = All<Trip>();

            var tripInfo = tripsQuery
                .Where(t => t.Id == tripId)
                .Select(t => new TripViewModel
                {
                    TripId = t.Id,
                    Description = t.Description,
                    ImagePath = t.ImagePath,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats
                })
                .FirstOrDefault();

            return tripInfo;
        }
    }
}
