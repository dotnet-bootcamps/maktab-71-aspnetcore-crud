using Microsoft.EntityFrameworkCore;

namespace Mvc01.Models;

public class ShopDbContext : DbContext
{
    public ShopDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            @"Server=(LocalDb)\MSSQLLocalDB; Initial Catalog=EShooopDb; Integrated Security=True");
    }

    public DbSet<ProductModel> Products { get; set; }
}