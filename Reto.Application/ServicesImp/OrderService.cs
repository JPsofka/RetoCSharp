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
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _repositoryWrapper.Order.GetAll();
        }

        public Order? GetOrderById(int id)
        {
            return _repositoryWrapper.Order.FindById(id);
        }
        public Task<Order> CreateOrder(Order order)
        {
            return _repositoryWrapper.Order.Add(order);
        }

        public bool DeleteOrder(int id)
        {
            var existent = _repositoryWrapper.Order.FindById(id);
            if(existent != null)
            {
                return _repositoryWrapper.Order.Delete(existent).Result;
            }
            return false;
        }


        public Task<bool> UpdateOrder(int id, Order order)
        {
            var existent = _repositoryWrapper.Order.FindById(id);
            return _repositoryWrapper.Order.Update(order);
        }
    }
}
