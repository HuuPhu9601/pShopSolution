using pShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Entities
{
    public class Promotion
    {
        public int Id { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public decimal? DiscountAmount { set; get; }
        public string ProductIds { set; get; }
        public string ProductCategoryIds { set; get; }
        public status Status { set; get; }
        public string Name { set; get; }
    }
}
