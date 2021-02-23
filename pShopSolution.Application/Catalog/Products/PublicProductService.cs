using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        public PageViewModel<ProductViewModel> GetAllByCategoryId(int categoryId, int pageindex, int pagesize)
        {
            throw new NotImplementedException();
        }
    }
}
