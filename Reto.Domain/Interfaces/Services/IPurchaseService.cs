using Reto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Interfaces.Services
{
    public interface IPurchaseService
    {
        IEnumerable<Purchase> GetPurchases();
        Purchase? GetPurchase(int id);
        Purchase CreatePurchase(Purchase  purchase);
        bool UpdatePurchase(int id, Purchase purchase);
        bool DeletePurchase(int id);
    }
}
