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

        public IEnumerable<Order> GetOrders()
        {
            return _repositoryWrapper.Order.GetAll();
        }

        public OrderDto? GetOrderById(int id)
        {
            List<Purchase> purchases = _purchaseService.GetPurchases().ToList();

            
            Order? order = _repositoryWrapper.Order.FindById(id);

            OrderDto orderDto = new OrderDto();
            if (order != null)
            {
                orderDto = _mapper.MapToOrderDto(order, purchases.FindAll(x => x.OrderId == id));
            }

            return orderDto;
        }

        public OrderDto CreateOrder(OrderDto orderDto)
        {   
            List<Purchase> purchases = orderDto.Purchases!;

            foreach (var purchase in purchases)
            {
                Product? product = _productService.GetProductById(purchase.ProductId);
                if(product == null && product?.InInventory >= purchase.Quantity && product.Min>= purchase.Quantity 
                    && product.Max<= purchase.Quantity)
                {
                    _repositoryWrapper.Order.Add(_mapper.MapToOrder(orderDto));
                    purchase.PurchaseId = orderDto.OrderId;
                    _purchaseService.CreatePurchase(purchase);
                }
                

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
