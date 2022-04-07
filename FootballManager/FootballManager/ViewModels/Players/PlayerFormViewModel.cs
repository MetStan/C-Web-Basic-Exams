
namespace FootballManager.ViewModels.Players
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class PlayerFormViewModel
    {
        [Required]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; init; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(PictureUrlMaxLength)]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(PositionNameMaxLength, MinimumLength = PositionNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Position { get; init; }

        [Required]
        [Range(SpeedMinValue, SpeedMaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public byte Speed { get; init; }

        [Required]
        [Range(EnduranceMinValue, EnduranceMaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public byte Endurance { get; init; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(DescriptionMaxLength, ErrorMessage = "{0} must be less than {1} characters.")]
        public string Description { get; init; }
    }
}
