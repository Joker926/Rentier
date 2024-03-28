using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentier.DTO
{
    public class ComputedResult
    {
        public required string SummaryText { get; set; }
        public decimal Result { get; set; }
    }
}
