using Reto.Domain.Dtos;
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
        OrderDto? GetOrderById(int id);
        OrderDto CreateOrder(OrderDto orderDto);
        bool DeleteOrder(int id);


    }
}
