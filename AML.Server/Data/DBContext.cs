using AML.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AML.Server.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaStock> MediaStock { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
