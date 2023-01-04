using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Repositories;
using Reto.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Application.ServicesImp
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PurchaseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return _repositoryWrapper.Purchase.GetAll();
        }

        public Purchase? GetPurchase(int id)
        {
            return _repositoryWrapper.Purchase.FindById(id);
        }

        public Purchase CreatePurchase(Purchase purchase)
        {
            return _repositoryWrapper.Purchase.Add(purchase);
        }

        public bool DeletePurchase(int id)
        {
            var existent = GetPurchase(id);
            if (existent is not null)
            {
                return _repositoryWrapper.Purchase.Delete(existent).Result;
            }
            return false;
        }        

        public bool UpdatePurchase(int id, Purchase purchase)
        {
            return _repositoryWrapper.Purchase.Update(purchase).Result;
        }
    }
}
