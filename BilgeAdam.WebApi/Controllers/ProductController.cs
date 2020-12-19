using BilgeAdam.WebApi.Contracts;
using BilgeAdam.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeAdam.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        //api/product/1
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return service.GetProduct(id);
        }

        //api/product/list?page=1&itemcount=10
        [HttpGet("list")]
        public IEnumerable<ProductDto> List([FromQuery]int page, [FromQuery]int count)
        {
            return service.GetProducts(page, count);
        }

        //api/product/save
        [HttpPost("save")]
        public int Save([FromBody]ProductInputDto data)
        {
            return service.SaveProduct(data);
        }
    }
}
