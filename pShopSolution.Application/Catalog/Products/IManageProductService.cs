using Microsoft.AspNetCore.Http;
using pShopSolution.ViewModels.Catalog.ProductImages;
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
        Task<int> Create(CreateProductRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductVm> GetById(int productId, string languageId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewcount(int productId);

        Task<PageResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PageResult<ProductVm>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

        //Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        //Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        //Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

    }
}
