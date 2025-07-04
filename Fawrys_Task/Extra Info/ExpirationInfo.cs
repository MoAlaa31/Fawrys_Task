using Fawrys_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawrys_Task.Extra_Info
{
    public class ExpirationInfo : IExpirable
    {
        public DateOnly ExpirationDate { get; set; }

        public bool IsExpired() => DateOnly.FromDateTime(DateTime.Now) > ExpirationDate;
    }
}
