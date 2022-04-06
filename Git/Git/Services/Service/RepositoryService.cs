using Git.Data;
using Git.Data.Models;
using Git.Services.Contracts;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.Service
{
    public class RepositoryService : DBaseService<Repository>, IRepositoryService
    {

        private readonly IValidatorService validator;

        public RepositoryService(ApplicationDbContext data, 
               IValidatorService repoValidator) 
            : base(data)
        {
            validator = repoValidator;
        }

        public ICollection<string> CreateRepository(RepositoryFormViewModel model, string ownerId)
        {
            
            List<string> errors = validator.ValidateModel(model).ToList();

            if (errors.Any())
            {
                return errors;
            }

            var repo = new Repository
            {
               Name = model.Name,
               OwnerId = ownerId,
               IsPublic = model.RepositoryType == "Public" ? true : false,
            };

            this.db.Add(repo);
            db.SaveChanges();

            return errors.ToList();
        }

        public ICollection<RepositoryViewModel> GetAllPublicRepositories(string userId)
        {
            var repos = this.All().AsQueryable();

            if (UserIsOwner(userId))
            {
                repos = repos.Where(r => r.IsPublic || r.OwnerId == userId);
            }
            else
            {
                repos = repos.Where(r => r.IsPublic);
            }

            var allRepos = repos.OrderByDescending(r => r.CreatedOn)
                          .Select(a => new RepositoryViewModel
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Owner = a.Owner.Username,
                              CreatedOn = a.CreatedOn.ToShortDateString(),
                              Commits = a.Commits.Count
                          })
                          .ToList();

            return allRepos;
        }

        public bool UserIsOwner(string userId)
        {
            return db.Repositories.Any(r => r.OwnerId == userId);
        }
    }
}
