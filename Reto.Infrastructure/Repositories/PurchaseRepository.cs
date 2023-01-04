using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Repositories;
using Reto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Infrastructure.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
