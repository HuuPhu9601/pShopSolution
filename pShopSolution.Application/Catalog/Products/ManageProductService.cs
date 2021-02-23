using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Dtos;
using pShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using pShopSolution.Data.Entities;
namespace pShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly pShopDBContext _context;
        public ManageProductService(pShopDBContext context)
        {
            _context = context;
        }

        public Task<int> CreateProduct(CreateProductRequest request)
        {
            var product = new product()
            {
                price = request.Price,
            };
            _context.Products.Add(product);
            return _context.SaveChangesAsync();
        }

        public Task<int> Deleta(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PageViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageindex, int pagesize)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateProduct(EditProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
