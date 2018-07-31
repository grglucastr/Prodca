using Microsoft.EntityFrameworkCore;

namespace Prodca.Models
{
    public class ProdcaContext : DbContext
    {
        public DbSet<Category> Category {get; set;}
        
        public DbSet<Product> Product {get; set;}

        public ProdcaContext(DbContextOptions<ProdcaContext> options):base(options)
        {

        }

    }
}