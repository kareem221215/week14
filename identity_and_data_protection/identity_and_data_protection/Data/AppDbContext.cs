using identity_and_data_protection.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using identity_and_data_protection.Data;


namespace identity_and_data_protection.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
