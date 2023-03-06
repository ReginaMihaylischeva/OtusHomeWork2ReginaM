using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
