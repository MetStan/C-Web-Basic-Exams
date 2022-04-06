using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.Contracts
{
    public interface IRepositoryService
    {
        ICollection<string> CreateRepository(RepositoryFormViewModel model, string ownerId);

        ICollection<RepositoryViewModel> GetAllPublicRepositories(string userId);

        bool UserIsOwner (string userId);
    }
}
