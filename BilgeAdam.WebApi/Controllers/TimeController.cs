using Microsoft.AspNetCore.Mvc;
using System;

namespace BilgeAdam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet("local")]
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        [HttpGet("utc")]
        public DateTime GetUtcCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}