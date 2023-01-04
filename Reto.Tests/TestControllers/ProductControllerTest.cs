using Microsoft.AspNetCore.Mvc;
using Moq;
using Reto.Api.Controllers;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Tests.TestControllers
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductService> _mockProductService;

        public ProductControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
        }

        [Fact]
        public void GetAllProducts()
        {
            var products = new List<Product>();

            products.Add(new Product { ProductId = 1, Name = "IPhone", InInventory = 10, Enabled = 1, Max = 10, Min = 1 });
            products.Add(new Product { ProductId = 2, Name = "Shoes", InInventory = 10, Enabled = 1, Max = 10, Min = 1 });
            products.Add(new Product { ProductId = 3, Name = "T-shirt", InInventory = 10, Enabled = 1, Max = 10, Min = 1 });

            products.AsEnumerable();
            _mockProductService.Setup(_ => _.GetProducts()).Returns(products);
            var productController = new ProductController(_mockProductService.Object);

            var res = productController.GetAll();

            Assert.IsType<ActionResult<IEnumerable<Product>>>(res);
        }

        [Fact]
        public void GetByIdTest()
        {
            var product = new Product { ProductId = 1, Name = "Shoes", InInventory = 10, Enabled = 1, Max = 10, Min = 1 };

            _mockProductService.Setup(_ => _.GetProductById(It.IsAny<int>())).Returns(product);

            var productController = new ProductController(_mockProductService.Object);

            var res = productController.Get(It.IsAny<int>());

            Assert.IsType<ActionResult<Product>>(res);
        }


        [Fact]
        public void Delete() 
        {
            _mockProductService.Setup(_ => _.DeleteProduct(It.IsAny<int>())).Returns(It.IsAny<bool>());

            var productController = new ProductController(_mockProductService.Object);

            var res = productController.Delete(It.IsAny<int>());

            Assert.IsType<ActionResult<bool>>(res);
        }
    }
}
