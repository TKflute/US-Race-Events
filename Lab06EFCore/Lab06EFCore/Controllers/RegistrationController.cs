using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab06EFCore.Controllers
{
    public class RegistrationController : Controller
    {
        private IRegistrationRepository repository;
        private Cart cart;
        public RegistrationController(IRegistrationRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public ViewResult Checkout()
        {
            List<String> tList = new List<String>();
            tList.Add("Runner");
            tList.Add("Volunteer");
            
            ViewData["TypeList"] =
                new SelectList(tList);
            return View(new Registration());
        }
        

        [HttpPost]
        public IActionResult Checkout(Registration registration)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                //associate CartLines w/ Registration
                registration.Lines = cart.Lines.ToArray();
                repository.SaveRegistration(registration);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                List<String> tList = new List<String>();
                tList.Add("Runner");
                tList.Add("Volunteer");

                ViewData["TypeList"] =
                    new SelectList(tList);
                return View(registration);
            }
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }

        public ViewResult List() =>
           View(repository.Registrations.Where(r => !r.Processed));

        [HttpPost]
        public IActionResult MarkProcessed(int registrationId)
        {
           Registration registration = repository.Registrations
                .FirstOrDefault(r => r.RegistrationID == registrationId);

            if (registration != null)
            {
                registration.Processed = true;
                repository.SaveRegistration(registration);
            }

            return RedirectToAction(nameof(List));
        }

    }
}