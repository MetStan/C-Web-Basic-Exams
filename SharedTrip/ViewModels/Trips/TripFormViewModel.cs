

namespace SharedTrip.ViewModels.Trips
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class TripFormViewModel
    {
        [Required]
        [MaxLength(PointNameMaxLength)]
        public string StartPoint { get; set; }

        [Required]
        [MaxLength(PointNameMaxLength)]
        public string EndPoint { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Range(2, 6, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Seats { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength, ErrorMessage = "{0} must be less than {1} characters.")]
        public string Description { get; set; }

       
        [MaxLength(PictureUrlMaxLength)]
        public string ImagePath { get; set; }
    }
}
