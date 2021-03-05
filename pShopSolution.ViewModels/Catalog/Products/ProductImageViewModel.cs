using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.ViewModels.Catalog.Products
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }

        public string Filepath { get; set; }

        public bool IsDefault { get; set; }

        public long FileSize { get; set; }
    }
}
