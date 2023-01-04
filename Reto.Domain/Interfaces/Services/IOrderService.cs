using Reto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order? GetOrderById(int id);
        Order CreateOrder(Order order);
        Task<bool> UpdateOrder(int id, Order order);
        bool DeleteOrder(int id);


    }
}
