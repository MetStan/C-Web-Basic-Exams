using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.Contracts
{
    public interface ICommitService
    {
        ICollection<string> CreateCommit(CommitFormViewModel model, string userId);

        ICollection<CommitViewModel> GetAllCommits(string userId);

        string DeleteCommit(string userId, string commitId);

        CommitToRepositoryViewModel CommitToRepository(string id);
    }
}
