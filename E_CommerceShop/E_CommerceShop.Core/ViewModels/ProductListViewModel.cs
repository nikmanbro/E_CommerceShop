using E_CommerceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceShop.Core.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable <Products> Products { get; set; }

        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
