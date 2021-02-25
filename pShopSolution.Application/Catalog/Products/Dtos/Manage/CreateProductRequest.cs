﻿using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Application.Catalog.Products.Dtos.Manage
{
    public class CreateProductRequest
    {

        public decimal price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Stock { get; set; }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Details { set; get; }

        public string SeoDescription { set; get; }

        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }
    }
}
