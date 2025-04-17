using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TechnicalTests.Api.Entities;

namespace TechnicalTests.Api.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API config if needed later
        }
    }
}
