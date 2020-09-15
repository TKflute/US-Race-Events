using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab06EFCore.Controllers
{
    public class AdminController : Controller
    {
        private IRaceRepository repository;
        public AdminController(IRaceRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index() =>
            View(repository.Races);

        public ViewResult Edit(int raceId) =>
            View(repository.Races.FirstOrDefault(p => p.RaceId == raceId));

        [HttpPost]
        public IActionResult Edit(Race race)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRace(race);
                TempData["message"] = $"{race.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                //something wrong w/ data values
                return View(race);
            }
        }

        public IActionResult Create() =>
            View("Edit", new Race());

        [HttpPost]
        public IActionResult Delete(int raceId)
        {
            Race deletedRace = repository.DeleteRace(raceId);
            if (deletedRace != null)
            {
                TempData["message"] = $"{deletedRace.Name} was deleted";
            }

            return RedirectToAction("Index");
        }
    }
}