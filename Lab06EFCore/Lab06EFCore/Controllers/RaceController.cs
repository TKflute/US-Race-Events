using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Lab06EFCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab06EFCore.Controllers
{
    public class RaceController : Controller
    {
        private IRaceRepository raceRepo;

        private int pageSize = 3;
        public RaceController(IRaceRepository raceRepo)
        {
            this.raceRepo = raceRepo;
        }

        public IActionResult List(string category, int pageId = 1)
        => View(new RaceListViewModel
        {
            Races = raceRepo.Races
            .Where(p => category == null || p.Category == category)
            .OrderBy(r => r.RaceId)
            //if page is 1, don't skip any items (will be 0 * pageSize)
            .Skip((pageId - 1) * pageSize)
            .Take(pageSize),

            PagingInfo = new PagingInfo()
            {
                CurrentPage = pageId,
                ItemsPerPage = pageSize,
                TotalItems = category == null ?
                raceRepo.Races.Count() :
                raceRepo.Races
                    .Where(e => e.Category == category)
                    .Count()
            },

            CurrentCategory = category
        });
    }
}