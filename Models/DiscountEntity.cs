using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BespokenBikes.Models
{
    public class DiscountEntity
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double DiscountPct { get; set; }
    }
}
