using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_CRUD.Models
{
    public class AddProduct
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; } = 0;

        //public ProductCategory Category { get; set; }
    }

}
