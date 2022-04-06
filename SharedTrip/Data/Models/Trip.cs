namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Trip
    {
        public Trip()
        {
            Id = Guid.NewGuid().ToString();
            UserTrips = new List<UserTrip>();
        }

        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(PointNameMaxLength)]
        public string StartPoint { get; set; }

        [Required]
        [MaxLength(PointNameMaxLength)]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [MaxLength(PictureUrlMaxLength)]
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}