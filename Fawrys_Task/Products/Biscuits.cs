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
    public class Biscuits : Product, IShippable, IExpirable
    {
        private readonly ExpirationInfo expirationInfo;
        private readonly ShippingInfo shippingInfo;
        public Biscuits(string name, double price, int quantity, DateOnly expirationDate, double weight)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            expirationInfo = new ExpirationInfo { ExpirationDate = expirationDate };
            shippingInfo = new ShippingInfo { Name = name, Weight = weight };
        }

        public bool IsExpired() => expirationInfo.IsExpired();
        public string GetName() => shippingInfo.GetName();
        public double GetWeight() => shippingInfo.GetWeight();
    }
}
