using Reto.Domain.Entities;
using Reto.Domain.Interfaces.Repositories;
using Reto.Domain.Interfaces.Services;

namespace Reto.Application.ServicesImp
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repositoryWrapper.Product.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _repositoryWrapper.Product.FindById(id);
        }

        public Product CreateProduct(Product product)
        {
            return _repositoryWrapper.Product.Add(product);
        }

        public bool DeleteProduct(int id)
        {
            var existent = GetProductById(id); 
            if(existent is not null)
            {
                return _repositoryWrapper.Product.Delete(existent).Result;
            }
            return false;
        }

        public bool UpdateProduct(int id, Product product)
        {
            return _repositoryWrapper.Product.Update(product).Result;   
        }
    }
}
