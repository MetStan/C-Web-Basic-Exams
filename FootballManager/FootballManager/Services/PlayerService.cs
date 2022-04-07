namespace FootballManager.Services
{
    using FootballManager.Contracts;
    using FootballManager.Data;
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Players;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerService : Repository, IPlayerService
    {
        private readonly IValidatorService validator;

        public PlayerService(FootballManagerDbContext data,
        IValidatorService playerValidator)
            : base(data)
        {
            this.validator = playerValidator;
        }

        public string AddPlayer(int playerId, string userId)
        {
            var user = All<User>()
                 .FirstOrDefault(u => u.Id == userId);
            
            var player = All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            var error = string.Empty;

            if (user == null || player == null)
            {
                return error = "User or player not found";
            }

            var IsPlayerInCollection = All<UserPlayer>()
                .Any(x => x.PlayerId == playerId && x.UserId == userId);

            if (IsPlayerInCollection)
            {
                return error = "Player has been added in collection already.";
            }

            var newPlayer = new UserPlayer
            {
                UserId = userId,
                PlayerId = playerId,
            };

            db.Add(newPlayer);
            db.SaveChanges();

            return error;
        }

        public ICollection<string> CreatePlayer(PlayerFormViewModel model)
        {
            var errors = validator.ValidateModel(model).ToList();

            var IsPlayerExist = All<Player>()
                .Any(p => p.FullName == model.FullName);

            if (IsPlayerExist)
            {
                errors.Add($"Player with name {model.FullName} has been created already.");
            }

            if (errors.Any())
            {
                return errors;
            }

            var newPlayer = new Player
            {
                Description = model.Description,
                FullName = model.FullName,
                Position = model.Position,
                Endurance = model.Endurance,
                Speed = model.Speed,
                ImageUrl = model.ImageUrl,
            };

            db.Add(newPlayer);
            db.SaveChanges();

            return errors;
        }

        public ICollection<PlayerViewModel> GetAllPlayers()
        {
            var allPlayers = All<Player>()
                 .Select(x => new PlayerViewModel
                 {
                     PlayerId = x.Id,
                     Description = x.Description,
                     FullName = x.FullName,
                     ImageUrl = x.ImageUrl,
                     Position = x.Position,
                     Endurance = x.Endurance,
                     Speed = x.Speed,
                 })
                 .ToList();

            return allPlayers;
        }

        public ICollection<PlayerViewModel> GetUserCollection(string userId)
        {
            var userCollection = All<UserPlayer>()
                .Where(c => c.UserId == userId)
                .Select(x => new PlayerViewModel
                {
                    PlayerId = x.PlayerId,
                    Description = x.Player.Description,
                    FullName = x.Player.FullName,
                    ImageUrl = x.Player.ImageUrl,
                    Position = x.Player.Position,
                    Endurance = x.Player.Endurance,
                    Speed = x.Player.Speed,
                })
                .ToList();
            
            return userCollection;
        }

        public string RemovePlayer(int playerId, string userId)
        {
            var player = All<UserPlayer>()
                .FirstOrDefault(p => p.PlayerId == playerId && p.UserId == userId);

            var error = string.Empty;

            if (player == null)
            {
                return error = "Player not found in user collection";
            }

            db.Remove(player);
            db.SaveChanges();

            return error;
        }
    }
}
