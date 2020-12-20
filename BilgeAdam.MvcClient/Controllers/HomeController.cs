using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BilgeAdam.MvcClient.Models;
using BilgeAdam.MvcClient.Services.Abstractions;

namespace BilgeAdam.MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService service;
        private readonly IAuthService authService;

        public HomeController(ILogger<HomeController> logger, IProductService service, IAuthService authService)
        {
            _logger = logger;
            this.service = service;
            this.authService = authService;
        }

        public IActionResult Index()
        {
            var products = service.GetProducts(8, 15);
            var vm = new ProductViewModel
            {
                Products = products,
                ShowNew = authService.HasAccecssToNewProduct(),
                ShowPrevious = true
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
