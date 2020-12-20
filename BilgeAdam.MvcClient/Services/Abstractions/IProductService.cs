using BilgeAdam.WebApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeAdam.MvcClient.Services.Abstractions
{
    public interface IProductService
    {
        ProductDto GetProduct(int productId);

        IEnumerable<ProductDto> GetProducts(int pageNumber, int count);

        int SaveProduct(ProductInputDto data);
    }
}
