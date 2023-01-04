using Microsoft.AspNetCore.Mvc;
using Moq;
using Reto.Api.Controllers;
using Reto.Application.ServicesImp;
using Reto.Domain;
using Reto.Domain.Dtos;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Repositories;
using Reto.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Tests.TestServices
{
    public class OrderServiceTest
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapper;
        private readonly Mock<Mapper> _mapper;
        private readonly Mock<IPurchaseService> _purchaseService;
        private readonly Mock<IProductService> _productService;
        public OrderServiceTest()
        {
            _repositoryWrapper = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<Mapper>();
            _purchaseService= new Mock<IPurchaseService>();
            _productService= new Mock<IProductService>();
        }

        [Fact]
        public void GetAllOrders()
        {
            var orders = new List<Order>();
            var purchases = new List<Purchase>();
            purchases.Add(new Purchase { PurchaseId = 1, ProductId = 1, Quantity = 2, OrderId = 1 });
            orders.Add(new Order { OrderId = 1, Date = new DateTime(), IdType = "cc", IdClient = 1, ClientName = "paco"});

            _repositoryWrapper.Setup(_ => _.Order.GetAll()).Returns(orders.AsEnumerable<Order>);
            _productService.Setup(_ => _.GetProductById(It.IsAny<int>())).Returns(It.IsAny<Product>);
            _purchaseService.Setup(_=> _.CreatePurchase(It.IsAny<Purchase>())).Returns(It.IsAny<Purchase>());
            var orderService = new OrderService(_repositoryWrapper.Object, _mapper.Object, _purchaseService.Object, _productService.Object);
            
            var res = orderService.GetOrders();

            Assert.IsAssignableFrom<IEnumerable<OrderDto>>(res);
        }

    }
}
