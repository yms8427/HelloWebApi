using BilgeAdam.WebApi.Contracts;
using System.Collections.Generic;

namespace BilgeAdam.WebApi.Services
{
    public interface IProductService
    {
        ProductDto GetProduct(int productId);

        IEnumerable<ProductDto> GetProducts(int pageNumber, int count);

        int SaveProduct(ProductInputDto data);
    }
}