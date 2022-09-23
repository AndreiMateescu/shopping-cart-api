using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Model;
using System.Collections.Generic;

namespace ShoppingAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
