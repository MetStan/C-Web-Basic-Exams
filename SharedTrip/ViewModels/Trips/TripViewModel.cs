

namespace SharedTrip.ViewModels.Trips
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class TripViewModel
    {
        public string TripId { get; init; }

        public string StartPoint { get; init; }

        public string EndPoint { get; init; }

        public string DepartureTime { get; init; }

        public string ImagePath { get; init; }
        
        public string Description { get; init; }

        public int Seats { get; init; }
    }
}
