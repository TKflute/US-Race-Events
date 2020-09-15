using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Lab06EFCore.Controllers
{
    public class SponsorApplicationController : Controller
    {
        private ISponsorApplicationRepository repository;
        private IRaceRepository raceRepository;

        public SponsorApplicationController(ISponsorApplicationRepository repoService, IRaceRepository raceRepo)
        {
            repository = repoService;
            raceRepository = raceRepo;
        }

        [HttpGet]
        public ViewResult Process(int raceId)
        {
            //need this here for get request
            Race race = raceRepository.Races
                .FirstOrDefault(p => p.RaceId == raceId);

            List<String> bList = new List<String>();
            bList.Add("> $10,000");
            bList.Add("$5,000-$10,000");
            bList.Add("< $5,000");

            ViewData["BudgetList"] =
                new SelectList(bList);

            ViewData["Race"] = race.Name.ToString();
            return View(new SponsorApplication());
        }

        [HttpPost]
        public IActionResult Process(SponsorApplication sponsorApplication, int raceId)
        {
            /* didn't need to use repo for post, just needed to pass the id again from form
            Race race = raceRepository.Races
               .FirstOrDefault(p => p.RaceId == raceId);*/
            //sponsorApplication.Race = race;

            if (ModelState.IsValid)
            {
                repository.SaveSponsorApplication(sponsorApplication);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                List<String> bList = new List<String>();
                bList.Add("> $10,000");
                bList.Add("$5,000-$10,000");
                bList.Add("< $5,000");

                ViewData["BudgetList"] =
                    new SelectList(bList);
                return View(sponsorApplication);
            }
        }

        public ViewResult Completed()
        {
            return View();
        }
    }
}