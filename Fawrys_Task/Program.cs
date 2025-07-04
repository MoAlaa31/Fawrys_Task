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
            Customer Mohamed = new Customer()
            {
                Name = "Mohamed Alaa",
                Address = "Nasr City, Cairo",
                Balance = 1000
            };
            Customer customer = new Customer()
            {
                Name = "Hamdy Ahmed",
                Address = "El Shatby, Alex",
                Balance = 10000
            };

            Cart mohamedCart = new Cart();
            Cart customerCart = new Cart();
            //case 1
            mohamedCart.Add(cheese, 2);
            mohamedCart.Add(mobile, 1);
            mohamedCart.Add(scratchCard, 1);
            CheckoutService.Checkout(Mohamed, mohamedCart);
            mohamedCart.Clear();

            //case 2
            //customerCart.Add(cheese, 2);
            //customerCart.Add(mobile, 2);
            //customerCart.Add(scratchCard, 1);
            //CheckoutService.Checkout(customer, customerCart);
            //mohamedCart.Clear();

            //case 3
            //Biscuits biscuits = new Biscuits("Onero", 100, 3, new DateOnly(2025, 7, 1), 1);
            //mohamedCart.Add(biscuits, 2);
            //CheckoutService.Checkout(Mohamed, mohamedCart);
            //mohamedCart.Clear();
        }
    }
}
