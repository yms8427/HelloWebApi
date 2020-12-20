using BilgeAdam.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BilgeAdam.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DIController : ControllerBase
    {
        public DIController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service1 = HttpContext.RequestServices.GetService<INumberService>();
            var service2 = HttpContext.RequestServices.GetService<INumberService>();
            var service3 = HttpContext.RequestServices.GetService<INumberService>();
            service3.Increase();
            var a = service1.Increase();
            var b = service2.Increase();
            return Ok(b);
        }

        [HttpGet("bigstring")]
        public ActionResult<string> GetBigString()
        {
            var r = new Random();
            return new String('x', r.Next(100, 290) * 1024);
        }
    }
}