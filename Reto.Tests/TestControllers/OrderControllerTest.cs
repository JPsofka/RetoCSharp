using Microsoft.AspNetCore.Mvc;
using Moq;
using Reto.Api.Controllers;
using Reto.Domain.Dtos;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Tests.TestControllers
{
    public class OrderControllerTest
    {
        private readonly Mock<IOrderService> _mockOrderService;

        public OrderControllerTest()
        {
            _mockOrderService = new Mock<IOrderService>();
        }

        [Fact]
        public void GetAllOrders()
        {
            var orders = new List<OrderDto>();
            var purchases = new List<Purchase>();
            purchases.Add(new Purchase { PurchaseId = 1, ProductId = 1, Quantity = 2, OrderId = 1 });
            orders.Add(new OrderDto { OrderId = 1, Date = new DateTime(), IdType = "cc", IdClient = 1, ClientName = "paco", Purchases = purchases });

            purchases.AsEnumerable();
            _mockOrderService.Setup(_ => _.GetOrders()).Returns(orders);
            var orderController = new OrderController(_mockOrderService.Object);

            var res = orderController.GetAll();

            Assert.IsType<ActionResult<IEnumerable<OrderDto>>>(res);
        }

        [Fact]
        public void GetByIdTest()
        {
            var purchases = new List<Purchase>();
            purchases.Add(new Purchase { PurchaseId = 1, ProductId = 1, Quantity = 2, OrderId = 1 });
            var order = new OrderDto { OrderId = 1, Date = new DateTime(), IdType = "cc", IdClient = 1, ClientName = "paco", Purchases = purchases };
           
            _mockOrderService.Setup(_ => _.GetOrderById(It.IsAny<int>())).Returns(order);
            var orderController = new OrderController(_mockOrderService.Object);

            var res = orderController.Get(It.IsAny<int>());

            Assert.IsType<ActionResult<OrderDto>>(res);
        }


        [Fact]
        public void Delete()
        {
            _mockOrderService.Setup(_ => _.DeleteOrder(It.IsAny<int>())).Returns(It.IsAny<bool>());

            var orderController = new OrderController(_mockOrderService.Object);

            var res = orderController.Delete(It.IsAny<int>());

            Assert.IsType<ActionResult<bool>>(res);
        }
    }
    

}
