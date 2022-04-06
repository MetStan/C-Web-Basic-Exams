using Git.Services.Contracts;
using Git.ViewModels.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;

        public CommitsController(ICommitService _commitService)
        {
            commitService = _commitService;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            CommitToRepositoryViewModel repository = commitService.CommitToRepository(id);

            if (repository != null)
            {
                return View(repository);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CommitFormViewModel model)
        {
            var errors = commitService.CreateCommit(model, User.Id)
                .ToList();

            if (errors.Any() == false)
            {
                return Redirect("/Repositories/All");
            }

            return Error(errors);
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = commitService.GetAllCommits(User.Id);
            
            return View(commits);
        }

        public HttpResponse Delete(string id)
        {
            var error = commitService.DeleteCommit(User.Id,id);

            if (string.IsNullOrEmpty(error))
            {
                return Redirect("/Commits/All");
            }

            return Error(error);
        }
    }
}
