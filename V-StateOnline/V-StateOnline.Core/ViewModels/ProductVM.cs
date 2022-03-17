using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V_StateOnline.Core.Models;

namespace V_StateOnline.Core.ViewModels
{
   public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
