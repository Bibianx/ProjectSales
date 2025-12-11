using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
