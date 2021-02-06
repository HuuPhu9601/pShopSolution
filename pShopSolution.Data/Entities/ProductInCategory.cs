using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Entities
{
    public class ProductInCategory
    {
        public int ProductId { get; set; }

        public product Product { get; set; }

        public int CategoryId { get; set; }

        public category Category { get; set; }
    }
}
