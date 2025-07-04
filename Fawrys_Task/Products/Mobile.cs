using Fawrys_Task.Extra_Info;
using Fawrys_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fawrys_Task.Products
{
    public class Mobile : Product, IShippable
    {
        private readonly ShippingInfo shippingInfo;
        public Mobile(string name, double price, int quantity, double weight)
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
