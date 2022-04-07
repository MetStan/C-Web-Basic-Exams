namespace FootballManager.ViewModels.Players
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }

        public string FullName { get; init; }

        public string ImageUrl { get; init; }

        public string Position { get; init; }

        public byte Speed { get; init; }

        public byte Endurance { get; init; }

        public string Description { get; init; }
    }
}
