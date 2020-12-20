using BilgeAdam.WebApi.Contracts;
using System.Collections.Generic;

namespace BilgeAdam.WebApi.Services
{
    public class MongoDbProductService : IProductService
    {
        public ProductDto GetProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts(int pageNumber, int count)
        {
            throw new System.NotImplementedException();
        }

        public int SaveProduct(ProductInputDto data)
        {
            throw new System.NotImplementedException();
        }
    }
}