using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reto.Domain.Dtos;
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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_orderService.GetOrderById(0));
        }

        [HttpPost]
        public ActionResult<OrderDto> Create(OrderDto orderDto) 
        {
            _orderService.CreateOrder()
            return CreatedAtAction(nameof(Get), new { id = orderDto.OrderId }, orderDto);
        }
    }
}
