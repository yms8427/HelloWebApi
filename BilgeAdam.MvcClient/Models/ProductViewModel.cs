using BilgeAdam.WebApi.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BilgeAdam.MvcClient.Models
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public bool HasProducts => Products.Any();
        public bool ShowNew { get; set; }
        public bool ShowNext => Products.Count() == 15;
        public bool ShowPrevious { get; set; }
    }
}