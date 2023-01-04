using Reto.Domain;
using Reto.Domain.Dtos;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Repositories;
using Reto.Domain.Interfaces.Services;


namespace Reto.Application.ServicesImp
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IPurchaseService _purchaseService;
        private readonly IProductService _productService;
        private Mapper _mapper;
        public OrderService(IRepositoryWrapper repositoryWrapper, Mapper mapper, IPurchaseService purchaseService, IProductService productService)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _purchaseService = purchaseService;
            _productService = productService;
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            List<OrderDto> orderDtos = new List<OrderDto>();
            List<Order> orders = _repositoryWrapper.Order.GetAll().ToList();
            foreach (var order in orders) 
            {
                List<Purchase> purchases = _purchaseService.GetPurchases().ToList();
                OrderDto orderDto = new OrderDto();
                if (order is not null)
                {
                    orderDto = _mapper.MapToOrderDto(order, purchases.FindAll(x => x.OrderId == order.OrderId));
                }
                orderDtos.Add(orderDto);
            }
            return orderDtos;

        }

        public OrderDto? GetOrderById(int id)
        {
            List<Purchase> purchases = _purchaseService.GetPurchases().ToList();

            Order? order = _repositoryWrapper.Order.FindById(id);
            OrderDto orderDto = new OrderDto();
            if (order is not null)
            {
                orderDto = _mapper.MapToOrderDto(order, purchases.FindAll(x => x.OrderId == id));
            }

            return orderDto;
        }

        public OrderDto CreateOrder(OrderDto orderDto)
        {   
            List<Purchase> purchases = orderDto.Purchases!;
            Order or = _repositoryWrapper.Order.Add(_mapper.MapToOrder(orderDto));
            var count = 0;
            foreach (var purchase in purchases)
            {
                Product? product = _productService.GetProductById(purchase.ProductId);
                if(product is not null && product?.InInventory >= purchase.Quantity && purchase.Quantity >= product.Min 
                    && purchase.Quantity<= product.Max)
                {
                    orderDto.Date = DateTime.Now;
                    orderDto.OrderId = or.OrderId;
                    purchase.OrderId = or.OrderId;
                    _purchaseService.CreatePurchase(purchase);
                    count++;
                    product.InInventory--;
                    Console.WriteLine(product.InInventory);
                    _productService.UpdateProduct(purchase.ProductId, product);
                }
                

            }
            if (count != purchases.Count())
            {
                DeleteOrder(or.OrderId);
            }
            return orderDto;

        }

        public bool DeleteOrder(int id)
        {
            var existent = _repositoryWrapper.Order.FindById(id);
            if(existent != null)
            {
                List<Purchase> purchases = _purchaseService.GetPurchases().ToList();
                foreach (var purchase in purchases)
                {
                    _purchaseService.DeletePurchase(purchase.PurchaseId);
                }
                return _repositoryWrapper.Order.Delete(existent).Result;

            }
            return false;
        }

    }
}
