using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Entities
{
    public class cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Guid UserId { get; set; }

        public product Product { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
