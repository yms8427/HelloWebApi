using BilgeAdam.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdam.WebApi.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}