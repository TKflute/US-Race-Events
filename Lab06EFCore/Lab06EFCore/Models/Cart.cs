using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Race Race, int quantity)
        {
            CartLine line = lineCollection
               .Where(p => p.Race.RaceId == Race.RaceId)
               .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Race = Race,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Race Race) =>
            lineCollection.RemoveAll(l => l.Race.RaceId == Race.RaceId);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => (decimal)e.Race.RegistrationFee * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;

        public class CartLine
        {
            public int CartLineId { get; set; }
            public Race Race { get; set; }
            public int Quantity { get; set; }
        }
    }
}
