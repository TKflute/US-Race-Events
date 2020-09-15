using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Infrastructure;
using Lab06EFCore.Models;
using Lab06EFCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab06EFCore.Controllers
{
    public class CartController : Controller
    {
        private IRaceRepository repository;
        private Cart cart;
        public CartController(IRaceRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public RedirectToActionResult AddToCart(int raceId, string returnUrl)
        {
            Race race = repository.Races
                .FirstOrDefault(p => p.RaceId == raceId);

            if (race != null)
            {
                cart.AddItem(race, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int raceId, string returnUrl)
        {
            Race race = repository.Races
                .FirstOrDefault(p => p.RaceId == raceId);

            if (race != null)
            {
                cart.RemoveLine(race);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}