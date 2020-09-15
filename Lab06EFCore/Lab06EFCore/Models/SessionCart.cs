using Lab06EFCore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();

            cart.Session = session;
            return cart;

        }

        public override void AddItem(Race race, int quantity)
        {
            base.AddItem(race, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Race race)
        {
            base.RemoveLine(race);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}

