using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class18Refactor
{
    interface IApplyDiscount
    {
        decimal ApplyDiscount(Discount discount);
    }
    interface IDiscountable
    {
        bool IsDiscountable();
    }
    interface IPriceCalculator
    {
        decimal CalculateTotalPrice();
    }

    /// <summary>
    /// Represents a shopping cart that can hold products, calculate total price,
    /// and apply discounts.
    /// </summary>
    public class ShoppingCart : IPriceCalculator, IDiscountable, IApplyDiscount
    {
        List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void PrintCart()
        {
            Console.WriteLine("Contenido de tu carrito:");
            foreach (var product in products)
            {
                Console.WriteLine($"- {product.Name}: {product.Price}");
            }
        }
        public bool IsDiscountable()
        {
            if (CalculateTotalPrice() > 25)
            {
                return true;
            }
            return false;
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            for (int i = 0; i < products.Count; i++)
            {
                totalPrice += products[i].Price;
            }
            return totalPrice;
        }

        public decimal ApplyDiscount(Discount discount)
        {
            decimal totalPrice = CalculateTotalPrice();
            return discount.ApplyDiscount(totalPrice);
        }
        public int GetProductCount()
        {
            return products.Count;
        }
    }
}
