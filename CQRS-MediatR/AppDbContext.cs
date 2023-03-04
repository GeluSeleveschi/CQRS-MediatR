using CQRS_MediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR
{
    public class AppDbContext : DbContext
    {
        public readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration) => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_configuration.GetConnectionString("sqlConnection"));

        public DbSet<Product> Products { get; set; }
    }
}
