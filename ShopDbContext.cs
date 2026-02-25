using Microsoft.EntityFrameworkCore;
using CRUD_Operations_Practice2.Models;
namespace CRUD_Operations_Practice2.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
        public DbSet<Shop> Shop { get; set; }
    }
}
