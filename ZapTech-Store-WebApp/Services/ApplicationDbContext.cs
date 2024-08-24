using Microsoft.EntityFrameworkCore;
using ZapTech_Store_WebApp.Models;

namespace ZapTech_Store_WebApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
