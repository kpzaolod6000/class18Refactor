using System;
using System.Collections.Generic;
using System.Threading;

namespace class18Refactor
{
    

    public class Program
    {
        public const decimal DEFAULT_DISCOUNT = 10m;

        private static ShoppingCart cart;
        private static List<Product> products; // products fake

        public static List<Product> GenerateProducts()
        {
            return new List<Product>
            {
                new Product("Manzana Roja", 1.20m),
                new Product("Plátano Maduro", 2.80m),
                new Product("Naranja Valencia", 2.50m),
                new Product("Pera Anjou", 3.75m),
                new Product("Uva Verde", 4.20m),
                new Product("Fresa Premium", 6.80m),
                new Product("Kiwi Orgánico", 5.40m),
                new Product("Mango Tropical", 8.90m),
                new Product("Piña Golden", 12.50m),
                new Product("Papaya Dulce", 7.30m),
                new Product("Melón Cantaloupe", 9.60m),
                new Product("Sandía Pequeña", 15.20m),
                new Product("Durazno Amarillo", 4.80m),
                new Product("Ciruela Roja", 5.90m),
                new Product("Cereza Dulce", 11.40m)
            };
        }
        static void InitializeSystem()
        {
            cart = new ShoppingCart();
            products = GenerateProducts();
        }

        static void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("════════════ PRODUCTOS DISPONIBLES ════════════");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - s./{products[i].Price}");
            }
            Console.WriteLine();
        }

        static void AddProductToCart()
        {
            ShowProducts();
            Console.Write("\nIngrese el número del producto: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");
            if (quantity < 1)
            {
                Console.WriteLine("Cantidad inválida. Debe ser mayor que 0.");
                return;
            }
            else
            {
                if (quantity > products.Count)
                {
                    Console.WriteLine("Producto no encontrado.");
                    return;
                }
                Product selectedProduct = products[quantity - 1];
                cart.AddProduct(selectedProduct);
                Console.WriteLine($"Producto '{selectedProduct.Name}' agregado al carrito.");
            }
        }

        static void ShowCart()
        {
            Console.Clear();
            if (cart.GetProductCount() > 0)
            {
                cart.PrintCart();
                Console.WriteLine($"Costo total del {cart.CalculateTotalPrice()}");
                return;
            }
            Console.WriteLine("El carrito está vacío. Por favor, agregue productos primero.");
        }

        static void CalculateTotal()
        {
            Console.Clear();
            if (cart== null || cart.CalculateTotalPrice() == 0)
            {
                Console.WriteLine("El carrito esta vacio. Por favor, agregue productos primero.");
                return;
            }
            if (products == null || products.Count == 0)
            {
                Console.WriteLine("No hay productos disponibles para calcular el total.");
                return;
            }
            decimal totalPrice = cart.CalculateTotalPrice();
            Console.WriteLine("Verificando si tiene descuento ...");
            Thread.Sleep(2000);
            cart.PrintCart();
            if (cart.IsDiscountable())
            {
                Discount discount = new Discount("Descuento de 10%", DEFAULT_DISCOUNT);
                totalPrice = cart.ApplyDiscount(discount);
                Console.WriteLine($"Total con descuento: s./{totalPrice}");
            }
            else
            {
                Console.WriteLine($"Total sin descuento: s./{totalPrice}");
            }
        }


        public static void ShowMenu()
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("========= SISTEMA DE CARRITO =========");
                Console.WriteLine("1. Ver productos disponibles");
                Console.WriteLine("2. Agregar producto al carrito");
                Console.WriteLine("3. Ver carrito");
                Console.WriteLine("4. Calcular total (con posible descuentos)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            ShowProducts();
                            break;
                        case 2:
                            AddProductToCart();
                            break;
                        case 3:
                            ShowCart();
                            break;
                        case 4:
                            CalculateTotal();
                            break;
                        case 0:
                            Console.WriteLine("¡Gracias por usar el sistema!");
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }

                    if (option != 0)
                    {
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                }
            } while (option != 0);
        }

        static void Main(string[] args)
        {
            InitializeSystem();
            ShowMenu();
        }
    }
}
