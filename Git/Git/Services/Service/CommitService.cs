using Git.Data;
using Git.Data.Models;
using Git.Services.Contracts;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.Service
{
    public class CommitService : DBaseService<Commit>, ICommitService
    {
        private readonly IValidatorService validator;

        public CommitService(ApplicationDbContext data,
            IValidatorService commitValidator)
            : base(data)
        {
            validator = commitValidator;
        }

        public CommitToRepositoryViewModel CommitToRepository(string id)
        {
            var repository = db.Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                })
                .FirstOrDefault();

            return repository;
        }

        public ICollection<string> CreateCommit(CommitFormViewModel model, string userId)
        {
            List<string> errors = validator.ValidateModel(model).ToList();

            if (errors.Any())
            {
                return errors;
            }

            var newCommit = new Commit
            {
                Description = model.Description,
                CreatorId = userId,
                RepositoryId = model.Id
            };

            db.Add(newCommit);
            db.SaveChanges();

            return errors;
        }

        public string DeleteCommit(string userId, string commitId)
        {
            var commit = All().FirstOrDefault(c => c.Id == commitId);

            string error = string.Empty;

            if (commit == null || commit.CreatorId != userId)
            {
                error = "Bad Request";
                return error;
            }

            db.Remove(commit);
            db.SaveChanges();

            return error;
        }

        public ICollection<CommitViewModel> GetAllCommits(string userId)
        {
            var commits = All().AsQueryable();

            var allCommits = commits
                        .Where(c => c.CreatorId == userId)
                        .OrderByDescending(c => c.CreatedOn)
                        .Select(ac => new CommitViewModel
                        {
                            Id = ac.Id,
                            Repository = ac.Repository.Name,
                            Description = ac.Description,
                            CreatedOn = ac.CreatedOn.ToShortDateString(),
                        })
                        .ToList();

            return allCommits;
        }
    }
}
