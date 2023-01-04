using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private Mapper _mapper;

        public OrderController(IOrderService orderService, Mapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_orderService.GetOrderById(0));
        }

        [HttpPost]
        public ActionResult<OrderDto> Create(OrderDto orderDto) 
        {

            _orderService.CreateOrder(orderDto);
            return CreatedAtAction(nameof(Get), new { id = orderDto.OrderId }, orderDto);
        }
    }
}
