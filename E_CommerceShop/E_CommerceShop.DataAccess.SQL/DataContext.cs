using E_CommerceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceShop.DataAccess.SQL
{
   public class DataContext:DbContext
    {
     public DataContext() : base("DefaultConnection")
        {
        }
        public DbSet<Products> Product { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
