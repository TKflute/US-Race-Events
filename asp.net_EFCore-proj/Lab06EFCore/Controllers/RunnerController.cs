using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Lab06EFCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab06EFCore.Controllers
{
    public class RunnerController : Controller
    {
        private IRunnerRepository runnerRepo;
        private int pageSize = 3;

        public RunnerController(IRunnerRepository runnerRepo)
        {
            this.runnerRepo = runnerRepo;
        }
        /*
        public IActionResult List()
        {
            return View(runnerRepo.Runners
                        .OrderBy(r => r.LastName)
                        .ThenBy(r => r.FirstName)
                        );
        }*/

        public IActionResult List(int page = 1)
        {
            RunnersListViewModel vModel = new RunnersListViewModel();

            IEnumerable<Runner> runners =
                runnerRepo.Runners
                .OrderBy(r => r.RunnerId)
                //if page is 1, don't skip any items (will be 0 * pageSize)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            vModel.Runners = runners;

            PagingInfo pInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = runnerRepo.Runners.Count()
            };

            vModel.PagingInfo = pInfo;

            return View(vModel);
        }
    }
}