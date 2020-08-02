using E_CommerceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceShop.Core.ViewModels
{
    public class ProductManagerViewModels
    {
        public Products Product { get; set; }

        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
