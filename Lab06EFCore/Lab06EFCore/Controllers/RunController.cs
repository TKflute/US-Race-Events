using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab06EFCore.Controllers
{
    public class RunController : Controller
    {
        private IRunRepository runRepo;

        public RunController(IRunRepository runRepo)
        {
            this.runRepo = runRepo;
        }

        public IActionResult List()
        {
            return View(runRepo.Runs.OrderBy(r => r.RunTime));
        }
    }
}