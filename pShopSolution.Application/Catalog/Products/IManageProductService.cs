using pShopSolution.Application.Catalog.Products.Dtos;
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

        Task<int> UpdateProduct(EditProductRequest request);

        Task<int> Deleta(int productId);

        Task<List<ProductViewModel>> GetAll();

        Task<PageViewModel<ProductViewModel>> GetAllPaging(string keyword,int pageindex, int pagesize);
    }
}
