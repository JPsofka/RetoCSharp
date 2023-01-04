using Reto.Domain.Dtos;
using Reto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain
{
    public class Mapper
    {
        public Mapper() { }
        public OrderDto MapToOrderDto(Order order, List<Purchase> purchases)
        {
            OrderDto orderDto = new OrderDto();
            orderDto.OrderId = order.OrderId;
            orderDto.Date = order.Date;
            orderDto.IdType = order.IdType;
            orderDto.IdClient = order.IdClient;
            orderDto.ClientName = order.ClientName;
            orderDto.Purchases = purchases;

            return orderDto;
        }

        public Order MapToOrder(OrderDto orderDto)
        {
            Order order = new Order();
            order.Date = orderDto.Date;
            order.IdType = orderDto.IdType;
            order.IdClient = orderDto.IdClient;
            order.ClientName = orderDto.ClientName;
            
            return order;
        }
    }
}
