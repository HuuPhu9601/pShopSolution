using pShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.ViewModels.Catalog.Products.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
