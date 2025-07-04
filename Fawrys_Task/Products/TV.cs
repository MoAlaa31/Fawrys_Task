using Fawrys_Task.Extra_Info;
using Fawrys_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawrys_Task.Products
{
    public class TV : Product, IShippable
    {
        private readonly ShippingInfo shippingInfo;
        public TV(string name, double price, int quantity, double weight)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            shippingInfo = new ShippingInfo { Name = name, Weight = weight };
        }

        public string GetName() => shippingInfo.GetName();
        public double GetWeight() => shippingInfo.GetWeight();
    }
}
