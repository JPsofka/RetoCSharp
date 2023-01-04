using Moq;
using Reto.Application.ServicesImp;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Tests.TestServices
{
    public class ProductServiceTest
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapper;
        public ProductServiceTest() 
        {
            _repositoryWrapper = new Mock<IRepositoryWrapper>();
        }

        [Fact]
        public void GetAllProducts()
        {
            var products = new List<Product>();

            products.Add(new Product { ProductId = 1, Name = "IPhone", InInventory = 10, Enabled = 1, Max = 10, Min = 1 });
            products.Add(new Product { ProductId = 2, Name = "Shoes", InInventory = 10, Enabled = 1, Max = 10, Min = 1 });
            products.Add(new Product { ProductId = 3, Name = "T-shirt", InInventory = 10, Enabled = 1, Max = 10, Min = 1 });

            _repositoryWrapper.Setup(_ => _.Product.GetAll()).Returns(products);

            var productService = new ProductService(_repositoryWrapper.Object);

            var res = productService.GetProducts();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetByIdProduct()
        {
            var product = new Product { ProductId = 1, Name = "IPhone", InInventory = 10, Enabled = 1, Max = 10, Min = 1 };

            _repositoryWrapper.Setup(_=>_.Product.FindById(It.IsAny<int>())).Returns(product);

            var productService = new ProductService(_repositoryWrapper.Object);

            var res = productService.GetProductById(It.IsAny<int>());

            Assert.NotNull(res);
        }

        [Fact]
        public void DeleteProduct() 
        {
            _repositoryWrapper.Setup(_ => _.Product.Delete(It.IsAny<Product>())).Returns(It.IsAny<Task<bool>>());

            var productService = new ProductService(_repositoryWrapper.Object);

            var res = productService.DeleteProduct(It.IsAny<int>());

            Assert.IsType<bool>(res);


        }
    }
}
