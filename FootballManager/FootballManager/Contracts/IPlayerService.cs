using FootballManager.ViewModels.Players;
using System.Collections.Generic;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        ICollection<string> CreatePlayer(PlayerFormViewModel model);
       
        ICollection<PlayerViewModel> GetAllPlayers();

        string AddPlayer(int playerId, string userId);
        
        ICollection<PlayerViewModel> GetUserCollection(string userId);
        
        string RemovePlayer(int playerId, string userId);
    }
}
