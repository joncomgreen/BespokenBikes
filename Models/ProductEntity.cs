using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BespokenBikes.Models
{
    public class ProductEntity
    {
        public Guid ProductGUID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        public double CommissionPct { get; set; }
    }
}
