using Ecommerce_CRUD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_CRUD.Services
{
    public class ProductServices : IProducts
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:3000/Data";

        public ProductServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<SucessMessage> CreateProductAsync(Product product)
        {
            var content = JsonConvert.SerializeObject(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_url, bodyContent);

            if (response.IsSuccessStatusCode)
            {
                return new SucessMessage { Message = "Product Created Successfully" };
            }

            throw new Exception("Product Creation Failed");
        }

        public async Task<SucessMessage> UpdateProductAsync(Product product)
        {
            var content = JsonConvert.SerializeObject(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(_url + "/" + product.ProductId, bodyContent);

            if (response.IsSuccessStatusCode)
            {
                return new SucessMessage { Message = "Product Updated Successfully" };
            }

            throw new Exception("Product Updating Failed");
        }

        public async Task<SucessMessage> DeleteProductAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(_url + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                return new SucessMessage { Message = "Product Deleted" };
            }

            throw new Exception("Product Deletion Failed");
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var response = await _httpClient.GetAsync(_url + "/" + id);
            var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                return product;
            }

            throw new Exception("Can't Get product");
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products;
            }

            throw new Exception("Can't Get products");
        }
    }
}
