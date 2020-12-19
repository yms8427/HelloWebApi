using BilgeAdam.WebApi.Contracts;
using BilgeAdam.WebApi.Data;
using BilgeAdam.WebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BilgeAdam.WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly NorthwindContext context;

        public ProductService(NorthwindContext context)
        {
            this.context = context;
        }
        public ProductDto GetProduct(int productId)
        {
            return context.Products.Where(w => w.ProductID == productId)
                                   .Select(s => new ProductDto
                                   {
                                       Id = s.ProductID,
                                       Name = s.ProductName,
                                       Price = s.UnitPrice,
                                       Stock = s.UnitsInStock
                                   })
                                   .FirstOrDefault();
        }

        public IEnumerable<ProductDto> GetProducts(int pageNumber, int count)
        {
            if (count > 15)
            {
                throw new InvalidOperationException("15 üründen daha fazla okuyamazsınız");
            }
            var skip = (pageNumber - 1) * count;
            return context.Products.OrderBy(o => o.ProductID)
                                   .Select(s => new ProductDto
                                   {
                                       Id = s.ProductID,
                                       Name = s.ProductName,
                                       Price = s.UnitPrice,
                                       Stock = s.UnitsInStock
                                   })
                                   .Skip(skip)
                                   .Take(count)
                                   .ToList();
        }

        public int SaveProduct(ProductInputDto data)
        {
            var @new = new Product
            {

            };
            context.Products.Add(@new);
            return context.SaveChanges();
        }
    }
}