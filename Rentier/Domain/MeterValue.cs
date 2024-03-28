using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.Domain
{
    public class MeterValue
    {
        public MeterValue() { }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Value { get; set; }

    }
}
