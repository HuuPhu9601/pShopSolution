using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Entities
{
    public class product
    {
        public int Id { get; set; }

        public decimal price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Stock { get; set; }

        public int ViewCount { get; set; }

        public DateTime DateCreated { get; set; }

        public string SeoAlias { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<cart> Carts { get; set; }

        public List<OrderDetail>OrderDetails { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}
