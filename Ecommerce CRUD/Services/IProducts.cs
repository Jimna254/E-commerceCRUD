using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Ecommerce_CRUD.Models;

namespace Ecommerce_CRUD.Services
{
    internal interface IProducts
    {
        //Adding a new Product 
        Task<SucessMessage> CreateProductAsync(Product product);
        //Update a Product
        Task<SucessMessage> UpdateProductAsync(Product product);
        //Delete a Product 
        Task<SucessMessage> DeleteProductAsync(string id);

        //Get one Product
        Task<Product> GetProductAsync(string id);

        //Get all Books
        Task<List<Product>> GetAllProductsAsync();


    }
}
