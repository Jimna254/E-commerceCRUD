using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_CRUD.Models
{
    public enum productcategory
    {
       Electronics,
       Clothing,
       Books,
       Beauty,
       Foodandbeaverages
    }


    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty; 

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; } = 0;

       public productcategory Category { get; set; }


    }

}
