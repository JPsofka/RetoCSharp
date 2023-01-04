using Reto.Domain.Interfaces.Repositories;
using Reto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private AppDbContext _appDbContext;
        private IProductRepository? _productRepository;
        private IOrderRepository? _orderRepository;
        private IPurchaseRepository? _purchaseRepository;
        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IProductRepository Product
        {
            get {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_appDbContext);
                }
                return _productRepository;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository= new OrderRepository(_appDbContext);
                }
                return _orderRepository;
            }
        }

        public IPurchaseRepository Purchase
        {
            get
            {
                if (_purchaseRepository == null)
                {
                    _purchaseRepository = new PurchaseRepository(_appDbContext);
                }
                return _purchaseRepository;
            }
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
            
        }
    }
}
