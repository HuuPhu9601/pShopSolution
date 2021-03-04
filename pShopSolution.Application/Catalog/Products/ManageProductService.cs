using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.ViewModels.Catalog.Products.Manage;
using pShopSolution.ViewModels.Common;
using pShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using pShopSolution.Data.Entities;
using pShopSolution.Utitlties.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using pShopSolution.Application.Comon;

namespace pShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly pShopDBContext _context;
        private readonly IStorageService _storageService;

        public ManageProductService(pShopDBContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int product, List<IFormFile> files)
        {
            throw new NotImplementedException();
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
            //save image
            if (request.ThumbnailImage !=null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = request.Name,
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        SortOrder = 1,
                    }
                };
            }

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Deleta(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new pShopException($"Cam not find a product : {productId}");

            //xoa file anh vat ly trc khi xoa san pham
            var images =  _context.ProductImages.Where(z => z.ProductId == productId);

            foreach (var item in images)
            {
               await _storageService.DeleteFileAsync(item.ImagePath);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
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

        public Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveImages(int imageId)
        {
            var RemoveImage = _context.ProductImages.Where(z => z.Id == imageId);
            if (RemoveImage != null)
            {
                _context.ProductImages.Remove((ProductImage)RemoveImage);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpadateImages(int imageId, string caption, bool isDefault)
        {
            var updateImage = await _context.ProductImages.FindAsync(imageId);
            if (updateImage != null)
            {
                updateImage.Caption = caption;
                updateImage.IsDefault = isDefault;
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new pShopException($"Cam not find a product with id : {productId}");
            product.price = newPrice;
            return await _context.SaveChangesAsync()>0;
        }


        public async Task<int> UpdateProduct(ProductUpdateRequest request)
        {
            var product =await _context.Products.FindAsync(request.Id);
            var productTranstation =await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if(product == null || productTranstation == null ) throw new pShopException($"Cam not find a product with id : {request.Id}");

            productTranstation.Name = request.Name;
            productTranstation.SeoAlias = request.SeoAlias;
            productTranstation.SeoDescription = request.SeoDescription;
            productTranstation.SeoTitle = request.SeoTitle;
            productTranstation.Description = request.Description;
            productTranstation.Details = request.Details;

            //save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage =await  _context.ProductImages.FirstOrDefaultAsync(z => z.IsDefault == true && z.ProductId == request.Id);
                if (thumbnailImage != null)
                {

                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
               
            }

            return  await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new pShopException($"Cam not find a product with id : {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        Task<PageResult<ProductViewModel>> IManageProductService.GetAllPaging(GetProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
