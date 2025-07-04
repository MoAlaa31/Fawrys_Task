using Fawrys_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fawrys_Task
{
    public class CheckoutService
    {
        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.Products.Count == 0)
            {
                Console.WriteLine("Error: Cart is empty.");
                return;
            }
            Console.WriteLine("** Checkout receipt **");
            Console.WriteLine("Item\t\tQty\tWeight\tUnit Price\tTotal");
            double subtotal = 0;
            double totalWeight = 0;
            List<IShippable> objects = new List<IShippable>();
            foreach (var item in cart.Products) 
            {
                bool ship = false;
                var product = item.Key;
                var quantity = item.Value;
                subtotal += (product.Price * quantity);
                if (!ValidateItem(product, quantity))
                    return;
                if (product is IShippable shippable)
                {
                    objects.Add(shippable);
                    ship = true;
                    totalWeight += (shippable.GetWeight()*quantity);
                    Console.WriteLine($"{product.Name,-12}\t{quantity,-3}\t{shippable.GetWeight()}g\t{product.Price,-10}\t{product.Price * quantity}");
                }
                else
                {
                    Console.WriteLine($"{product.Name,-12}\t{quantity,-3}\t-----\t{product.Price,-10}\t{product.Price*quantity}");
                }
            }
            var amount = subtotal + totalWeight;
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Subtotal\t{subtotal}");
            Console.WriteLine($"Shipping Fees\t{CalculateShippingFee(totalWeight)}");
            Console.WriteLine($"Amount\t\t{amount}");
            if (ValidateCustomer(customer, amount))
            {
                customer.Balance -= amount;
                Console.WriteLine($"Customer's current balance: {customer.Balance}");
            }
            ShippingService(objects);

            bool ValidateItem(Product p, int q)
            {
                if (p is IExpirable e && e.IsExpired())
                {
                    Console.WriteLine($"Error: {p.Name} is expired.");
                    return false;
                }

                if (q > p.Quantity)
                {
                    Console.WriteLine($"Error: Not enough stock for {p.Name}.");
                    return false;
                }

                return true;
            }
            bool ValidateCustomer(Customer customer, double amount)
            {
                if (customer.Balance < amount)
                {
                    Console.WriteLine($"Customer's balance is insufficient: {customer.Balance}.");
                    return false;
                }
                return true;
            }
        }
        //Amazon Easy Ship Weight-Handling Fees(Standard-Size):
        //- Up to 1 kg: 53 EGP
        //- Up to 1.5 kg: 57.5 EGP
        //- Up to 2 kg: 59.5 EGP
        //- Each additional 1 kg: +2 EGP
        private static double CalculateShippingFee(double totalWeightKg)
        {
            if (totalWeightKg <= 1)
                return 53;

            if (totalWeightKg <= 1.5)
                return 57.5;

            if (totalWeightKg <= 2)
                return 59.5;

            double extraWeight = totalWeightKg - 2;
            int extraKg = (int)Math.Ceiling(extraWeight);
            return 59.5 + (extraKg * 2);
        }
        private static void ShippingService(List<IShippable> objects)
        {
            // responsible for shipping
        }
    }
}
