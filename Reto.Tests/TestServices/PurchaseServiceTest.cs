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
    public class PurchaseServiceTest
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapper;
        public PurchaseServiceTest()
        {
            _repositoryWrapper = new Mock<IRepositoryWrapper>();
        }

        [Fact]
        public void GetAllPurchases()
        {
            var purchases = new List<Purchase>();

            purchases.Add(new Purchase { PurchaseId = 1, ProductId = 1, Quantity = 2, OrderId = 1 });
            purchases.Add(new Purchase { PurchaseId = 1, ProductId = 1, Quantity = 2, OrderId = 1 });

            _repositoryWrapper.Setup(_ => _.Purchase.GetAll()).Returns(purchases);

            var purchaseService = new PurchaseService(_repositoryWrapper.Object);

            var res = purchaseService.GetPurchases();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetByIdPurchase()
        {
            var purchase = new Purchase { PurchaseId = 1, ProductId = 1, Quantity = 2, OrderId = 1 };

            _repositoryWrapper.Setup(_ => _.Purchase.FindById(It.IsAny<int>())).Returns(purchase);

            var purchaseService = new PurchaseService(_repositoryWrapper.Object);

            var res = purchaseService.GetPurchase(It.IsAny<int>());

            Assert.NotNull(res);
        }

        [Fact]
        public void DeleteProduct()
        {
            _repositoryWrapper.Setup(_ => _.Purchase.Delete(It.IsAny<Purchase>())).Returns(It.IsAny<Task<bool>>());

            var purchaseService = new PurchaseService(_repositoryWrapper.Object);

            var res = purchaseService.DeletePurchase(It.IsAny<int>());

            Assert.IsType<bool>(res);


        }
    }
}
