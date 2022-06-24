using Microsoft.EntityFrameworkCore;
using ProductManagementModel;

namespace ProductManagementDBContext
{
    public class EFDBcontext:DbContext
    {
        public EFDBcontext() { }
        public EFDBcontext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> productService { get; set; }
        public DbSet<PlaceOfOrigin> place_of_origin { get; set; }

    }
}