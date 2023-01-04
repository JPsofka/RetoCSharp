using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reto.Application.ServicesImp;
using Reto.Domain;
using Reto.Domain.Dtos;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Services;

namespace Reto.Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            return Ok(_orderService.GetOrders());
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDto> Get(int id)
        {
            return Ok(_orderService.GetOrderById(id));
        }

        [HttpPost]
        public ActionResult<OrderDto> Create(OrderDto orderDto) 
        {

            _orderService.CreateOrder(orderDto);
            return CreatedAtAction(nameof(Get), new { id = orderDto.OrderId }, orderDto);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_orderService.DeleteOrder(id));
        }
    }
}
