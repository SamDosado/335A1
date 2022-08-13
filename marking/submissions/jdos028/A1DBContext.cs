using Microsoft.EntityFrameworkCore;
using A1.Models;

namespace A1.Data
{
    public class A1DbContext : DbContext
    {
        public A1DbContext(DbContextOptions<A1DbContext> options) : base(options) { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=(A1Database.sqlite)");
        }*/
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}

