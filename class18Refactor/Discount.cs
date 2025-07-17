using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class18Refactor
{
    public class Discount
    { 
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public Discount(string name, decimal percentage)
        {
            Name = name;
            Percentage = percentage;
        }
        public decimal ApplyDiscount(decimal price)
        {
            return price - (price * (Percentage / 100));
        }
    }
}
