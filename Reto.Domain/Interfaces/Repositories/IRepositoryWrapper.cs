using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        IPurchaseRepository Purchase { get; }
        void Save();
    }
}
