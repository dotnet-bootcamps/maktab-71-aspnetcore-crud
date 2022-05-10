using Microsoft.EntityFrameworkCore;
using Mvc01.Models;

namespace Mvc01.Infrastructures.Database
{
    public class ShopDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQL2019; Initial Catalog=ShopDb; Integrated Security=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
