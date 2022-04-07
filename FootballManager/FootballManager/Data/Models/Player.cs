namespace FootballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class Player
    {
        public Player()
        {
            UserPlayers = new List<UserPlayer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(PictureUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(20)]
        public string Position { get; set; }

        [Required]
        [MaxLength(2)]
        public byte Speed { get; set; }

        [Required]
        [MaxLength(2)]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }

}
