using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Catalog.Products.Dtos.Manage;
using pShopSolution.Application.Dtos;
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

        Task<List<ProductViewModel>> GetAll();

        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
