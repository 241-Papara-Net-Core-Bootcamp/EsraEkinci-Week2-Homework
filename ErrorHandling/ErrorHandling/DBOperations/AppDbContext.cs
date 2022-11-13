using ErrorHandling.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ErrorHandling.DBOperations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public AppDbContext(Func<DbContextOptions<AppDbContext>> getRequiredService)
        {
        }

        public DbSet<User> Users { get; set; }  

    }
}
