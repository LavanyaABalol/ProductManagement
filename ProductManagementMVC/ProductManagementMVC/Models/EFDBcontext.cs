using Microsoft.EntityFrameworkCore;

namespace ProductManagementMVC.Models
{
    public class EFDBcontext:DbContext
    {
        public EFDBcontext() { }
        public EFDBcontext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> products { get; set; }

        // Define Books entity of type DbSet<Book>

    }
}
