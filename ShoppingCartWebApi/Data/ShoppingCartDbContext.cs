using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Data
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {



        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<feedback> feedback { get; set; }

    }
}