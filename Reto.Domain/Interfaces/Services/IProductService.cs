using Reto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product? GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
    }
}
