using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Application.Catalog.Products.Dtos
{
    public class CreateProductRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
