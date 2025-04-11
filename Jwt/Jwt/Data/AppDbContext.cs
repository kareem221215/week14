using identity_and_data_protection.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace identity_and_data_protection.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
