using Fawrys_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawrys_Task.Extra_Info
{
    public class ShippingInfo: IShippable
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
