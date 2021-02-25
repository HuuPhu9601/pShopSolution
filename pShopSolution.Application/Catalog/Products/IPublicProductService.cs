using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Catalog.Products.Dtos.Public;
using pShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PageResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest);
    }
}
