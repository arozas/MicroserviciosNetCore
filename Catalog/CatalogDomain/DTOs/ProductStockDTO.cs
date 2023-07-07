using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDomain.DTOs
{
    internal class ProductStockDTO
    {
        public int ProductStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}
