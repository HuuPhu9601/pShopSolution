using pShopSolution.Application.Dtos;
using pShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using pShopSolution.Data.Entities;
using pShopSolution.Application.Catalog.Products.Dtos.Manage;
using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Utitlties.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace pShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly pShopDBContext _context;
        public ManageProductService(pShopDBContext context)
        {
            _context = context;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateProduct(CreateProductRequest request)
        {
            var product = new product()
            {
                price = request.price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId,
                    }
                }
            };  
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Deleta(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new pShopException($"Cam not find a product : {productId}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2. fillter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryIds.Count>0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }

            //3. Paging
            int totalRow =await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1)* request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                Id = x.p.Id,
                Name = x.pt.Name,
                DateCreated = x.p.DateCreated,
                Description = x.pt.Description,
                Details = x.pt.Details,
                LanguageId = x.pt.LanguageId,
                OriginalPrice = x.p.OriginalPrice,
                price = x.p.price,
                SeoAlias = x.pt.SeoAlias,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoTitle,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount
            }).ToListAsync(); ;

            //4. Select and projection
            var pagedResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data
            };
            return pagedResult;
        }

        public Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateProduct(ProductUpdateRequest request)
        {
            var product = _context.Products.Find(request.Id);
            if(request == null) throw new pShopException($"Cam not find a product : {productId}");
        }

        public Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            throw new NotImplementedException();
        }

        Task<List<ProductViewModel>> IManageProductService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<PageResult<ProductViewModel>> IManageProductService.GetAllPaging(GetProductPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
