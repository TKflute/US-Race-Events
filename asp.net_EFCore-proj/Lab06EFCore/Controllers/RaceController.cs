using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab06EFCore.Controllers
{
    public class RaceController : Controller
    {
        private IRaceRepository raceRepo;

        public RaceController(IRaceRepository raceRepo)
        {
            this.raceRepo = raceRepo;
        }
   
        public IActionResult List()
        {
            return View(raceRepo.Races
                        .OrderBy(r => r.Date)
                        );
        }
    }
}