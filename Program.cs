using System;
using System.Collections.Generic;

namespace ShoppingCartActivity
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int RemainingStock;

        public void DisplayProduct()
        {
            string status = RemainingStock == 0 ? "OUT OF STOCK" : RemainingStock.ToString();
            Console.WriteLine($"[{Id}] {Name,-25} | P{Price,8:N2} | Stock: {status}");
        }

        public bool HasEnoughStock(int quantity)
        {
            return quantity <= RemainingStock;
        }

        public void DeductStock(int quantity)
        {
            RemainingStock -= quantity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] storeMenu = new Product[]
            {
                new Product { Id = 1, Name = "Progynova 2mg(Pampa-Fresh)", Price = 1850.00, RemainingStock = 12 },
                new Product { Id = 2, Name = "Diane-35 (Thailand)", Price = 650.00, RemainingStock = 20 },
                new Product { Id = 3, Name = "Diane-35 (Germany)", Price = 1100.00, RemainingStock = 10 },
                new Product { Id = 4, Name = "Aldactone 100mg", Price = 950.00, RemainingStock = 15 },
                new Product { Id = 5, Name = "Androcur 50mg(anti muscle)", Price = 2600.00, RemainingStock = 5 },
                new Product { Id = 6, Name = "Barbie Arms Injectable(for a confident arms)", Price = 4800.00, RemainingStock = 8 },
                new Product { Id = 7, Name = "Estradiol Patch( a dominant estrogen to stabilize your fem hormones)", Price = 3500.00, RemainingStock = 4 },
                new Product { Id = 8, Name = "Neofollin (Injectable)()", Price = 4200.00, RemainingStock = 0 }
            };

            List<Product> cart = new List<Product>();
            List<int> cartQuantities = new List<int>();

            bool isShopping = true;

            Console.WriteLine("===========================================");
            Console.WriteLine("     TRANS-HEALTH HRT SPECIALTY SHOP       ");
            Console.WriteLine("===========================================");

            while (isShopping)
            {
                Console.WriteLine("\nOUR HRT PRODUCTS:");
                Console.WriteLine("-------------------------------------------");
                foreach (var p in storeMenu)
                {
                    p.DisplayProduct();
                }
                Console.WriteLine("-------------------------------------------");

                Console.Write("\nEnter Product ID (1-8): ");
                string productInput = Console.ReadLine();

                if (!int.TryParse(productInput, out int choice) || choice < 1 || choice > storeMenu.Length)
                {
                    Console.WriteLine(">> [ERROR] Invalid selection! Please choose 1-8.");
                    continue;
                }

                Product selected = storeMenu[choice - 1];

                if (selected.RemainingStock == 0)
                {
                    Console.WriteLine($">> [SORRY] {selected.Name} is not available.");
                    continue;
                }

                Console.Write($"Quantity for {selected.Name}: ");
                string qtyInput = Console.ReadLine();

                if (!int.TryParse(qtyInput, out int qty) || qty <= 0)
                {
                    Console.WriteLine(">> [ERROR] Please enter a valid quantity.");
                    continue;
                }

                if (!selected.HasEnoughStock(qty))
                {
                    Console.WriteLine($">> [ALERT] Insufficient stock! Only {selected.RemainingStock} left.");
                }
                else
                {
                    int indexInCart = cart.FindIndex(item => item.Id == selected.Id);

                    if (indexInCart != -1)
                    {
                        cartQuantities[indexInCart] += qty;
                    }
                    else
                    {
                        if (cart.Count >= 10)
                        {
                            Console.WriteLine(">> [LIMIT] Your cart is already full.");
                            break;
                        }
                        cart.Add(selected);
                        cartQuantities.Add(qty);
                    }

                    selected.DeductStock(qty);
                    Console.WriteLine($">> [SUCCESS] Added {qty} {selected.Name} to cart.");
                }

                Console.Write("\nAdd more items? (Y/N): ");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    isShopping = false;
                }
            }

            double grandTotal = 0;
            Console.WriteLine("\n\n===========================================");
            Console.WriteLine("             OFFICIAL RECEIPT              ");
            Console.WriteLine("===========================================");
            Console.WriteLine($"{"Item",-20} | {"Qty",-3} | {"Total",-10}");
            Console.WriteLine("-------------------------------------------");

            for (int i = 0; i < cart.Count; i++)
            {
                double subtotal = cart[i].Price * cartQuantities[i];
                grandTotal += subtotal;
                Console.WriteLine($"{cart[i].Name,-20} | {cartQuantities[i],-3} | P{subtotal,10:N2}");
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{"SUBTOTAL:",-26} P{grandTotal,10:N2}");

            double finalTotal = grandTotal;
            if (grandTotal >= 5000)
            {
                double discount = grandTotal * 0.10;
                finalTotal = grandTotal - discount;
                Console.WriteLine($"{"DISCOUNT (10%):",-26} -P{discount,10:N2}");
            }

            Console.WriteLine($"{"FINAL TOTAL:",-26} P{finalTotal,10:N2}");
            Console.WriteLine("===========================================");

            Console.WriteLine("\nUPDATED INVENTORY:");
            foreach (var p in storeMenu)
            {
                Console.WriteLine($"- {p.Name}: {p.RemainingStock} left");
            }

            Console.WriteLine("\nThank you! Stay transition-ready! happy transitioning");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}