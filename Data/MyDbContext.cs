using Microsoft.EntityFrameworkCore;
using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go
{
    public class MyDbContext:DbContext
    {
      public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => entity.HasIndex(u => u.Email).IsUnique()); //here we're making sure email is unique amoung all users in the users db table
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<StockProduct> StockProducts { get; set; }
        public DbSet<History> histories { get; set; }

        

    }
}
