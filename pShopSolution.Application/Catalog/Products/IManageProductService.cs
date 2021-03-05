using Microsoft.AspNetCore.Http;
using pShopSolution.ViewModels.Catalog.Products;
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

        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImages(int productId, List<IFormFile> files);

        Task<int> RemoveImages(int imgeId);

        Task<int> UpadateImages(int imageId, string caption, bool isDefault);

        Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
