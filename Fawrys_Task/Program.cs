using Fawrys_Task.Products;

namespace Fawrys_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cheese cheese = new Cheese("Cheddar", 100, 3, new DateOnly(2025, 7, 6), 1);
            Mobile mobile = new Mobile("Iphone", 1000, 5, 0.400);
            ScratchCard scratchCard = new ScratchCard("Vodafone", 50, 10);
            Customer Mohamed = new Customer();
            Mohamed.Balance = 1000;
            Cart cart = new Cart();
            cart.Add(cheese, 2);
            cart.Add(mobile, 1);
            cart.Add(scratchCard, 1);
            CheckoutService.Checkout(Mohamed, cart);
        }
    }
}
