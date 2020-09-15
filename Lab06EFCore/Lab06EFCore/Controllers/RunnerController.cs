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
       // private int pageSize = 3;

        public RunnerController(IRunnerRepository runnerRepo)
        {
            this.runnerRepo = runnerRepo;
        }
        
        public IActionResult List()
        {
            return View(runnerRepo.Runners
                        .OrderBy(r => r.LastName)
                        .ThenBy(r => r.FirstName)
                        );
        }
        /*
        public IActionResult List(string category, int pageId = 1)
             => View(new RaceListViewModel
        {
            Runners = runnerRepo.Runners
                .Where(p => category == null || p.Category == category)
                .OrderBy(r => r.RunnerId)
                //if page is 1, don't skip any items (will be 0 * pageSize)
                .Skip((pageId - 1) * pageSize)
                .Take(pageSize),

            PagingInfo = new PagingInfo()
            {
                CurrentPage = pageId,
                ItemsPerPage = pageSize,
                TotalItems = category == null ?
                    runnerRepo.Runners.Count() :
                    runnerRepo.Runners
                        .Where(e => e.Category == category)
                        .Count()
            },

            CurrentCategory = category
        });*/
    }
}