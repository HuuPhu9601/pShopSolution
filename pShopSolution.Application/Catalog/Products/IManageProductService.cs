
using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.ViewModels.Catalog.Products.Manage;
using pShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> CreateProduct(CreateProductRequest request);

        Task<int> UpdateProduct(ProductUpdateRequest request);

        Task<int> Deleta(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewCount(int productId);

        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
