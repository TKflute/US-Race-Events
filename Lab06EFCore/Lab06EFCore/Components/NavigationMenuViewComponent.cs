using Lab06EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IRaceRepository repository;

        public NavigationMenuViewComponent(IRaceRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            //***This is where I would need to add data to view by age or gender (I think)
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Races
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)); 
        }
    }
}
