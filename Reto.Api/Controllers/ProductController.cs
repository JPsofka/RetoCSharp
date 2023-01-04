using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Services;

namespace Reto.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _productService.GetProducts().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, Product product) 
        {
            return Ok(_productService.UpdateProduct(id, product));   
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_productService.DeleteProduct(id));
        }
    }
}
