using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawrys_Task
{
    public class Cart
    {
        public Dictionary<Product, int> Products = new Dictionary<Product, int>();
        public void Add(Product product, int quantity)
        {
            if (Products.TryGetValue(product, out int currentQuantity))
                Products[product] = currentQuantity + quantity;
            else
                Products.Add(product, quantity);
        }
        public void Delete(Product product, int quantity)
        {
            if (Products.TryGetValue(product, out int currentQuantity))
            {
                if (quantity >= currentQuantity)
                {
                    Products.Remove(product);
                }
                else
                {
                    Products[product] = currentQuantity - quantity;
                }
            }
            else
            {
                Console.WriteLine("This product is not in the Cart");
            }
        }
        public void Clear()
        {
            Products.Clear();
        }
    }
}
