using pShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Entities
{
    public class category
    {
        public int Id { get; set; }

        public int SortOder { get; set; }

        public bool IsShowOnHome { get; set; }

        public int? ParentId { get; set; }

        public status Status { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<categoryTranslation> CategoryTranslations { get; set; }
    }
}
