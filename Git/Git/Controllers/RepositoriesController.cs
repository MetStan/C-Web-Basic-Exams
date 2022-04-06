using Git.Services.Contracts;
using Git.ViewModels.Repositories;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;
using System.Linq;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repoService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
           repoService = repositoryService;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(RepositoryFormViewModel model)
        {
            var errors = repoService.CreateRepository(model, User.Id);

            if (errors.Any())
            {
                return Error(errors);
            }

            return Redirect("/Repositories/All");
        }

       
        public HttpResponse All()
        {
            var allRepos = repoService.GetAllPublicRepositories(User.Id);

            return View(allRepos);
        }
    }
}
