using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pShopSolution.Application.Catalog.Products;
using pShopSolution.ViewModels.Catalog.Products;

namespace pShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _manageProductService = manageProductService;
            _publicProductService = publicProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _publicProductService.GetAll();
            return Ok(products);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(request);
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _manageProductService.GetById(productId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest create)
        {
            var productId = await _manageProductService.CreateProduct(create);
            if (productId == 0)
            {
                return BadRequest();
            }

            var products = await _manageProductService.GetById(productId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, products);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest update)
        {
            var affectedResult = await _manageProductService.UpdateProduct(update);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _manageProductService.Deleta(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("price/{id}/{newprice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int id, decimal newprice)
        {
            var isSeccusful = await _manageProductService.UpdatePrice(id,newprice);
            if (isSeccusful)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
