using pShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string languageId { get; set; }
        public int? CategoryId { get; set; }
    }
}
