﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce_CRUD.Helpers;
using Ecommerce_CRUD.Models;
using Ecommerce_CRUD.Services;

namespace Ecommerce_CRUD.Controllers
{
    public class ProductsController
    {
        private ProductServices productService = new ProductServices();

        public async Task StartMenu()
        {
            while (true) // Keep the menu recurring until exit
            {
                Console.WriteLine("Hello, welcome to The Ecommerce Store");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update a Product");
                Console.WriteLine("4. Delete a Product");
                Console.WriteLine("5. Exit");

                var input = Console.ReadLine();

                if (input == "5")
                {
                    Console.WriteLine("Exiting the menu...");
                    break; // Exit the loop and the menu
                }

                var validateResults = Validation.Validate(new List<string> { input });

                if (!validateResults)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
                else
                {
                    await MenuRedirect(input);
                }
            }
        }

        public async Task MenuRedirect(string id)
        {
            switch (id)
            {
                case "1":
                    await AddNewProduct();
                    break;
                case "2":
                    await ViewProducts();
                    break;
                case "3":
                    await UpdateProduct();
                    break;
                case "4":
                    await DeleteProduct();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
        public async Task AddNewProduct()
        {
            Console.WriteLine("Enter Product Name:");
            var productName = Console.ReadLine();

            Console.WriteLine("Enter Product Description:");
            var productDescription = Console.ReadLine();

            Console.WriteLine("Enter Product Price:");
            var productPriceStr = Console.ReadLine();

            if (int.TryParse(productPriceStr, out int productPrice))
            {
                var newProduct = new Product
                {
                    Name = productName,
                    Description = productDescription,
                    Price = productPrice
                };

                try
                {
                    var res = await productService.CreateProductAsync(newProduct);
                    Console.WriteLine(res.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Price. Please enter a valid numeric value.");
            }
        }
        public async Task UpdateProduct()
        {
            await ViewProducts();
            Console.WriteLine("Enter the Id of the Product you want to update:");
            var id = Console.ReadLine();

            if (int.TryParse(id, out int productId))
            {
                Console.WriteLine("Enter Product Name:");
                var productName = Console.ReadLine();

                Console.WriteLine("Enter Product Description:");
                var productDescription = Console.ReadLine();

                Console.WriteLine("Enter Product Price:");
                var productPriceStr = Console.ReadLine();

                if (int.TryParse(productPriceStr, out int productPrice))
                {
                    var updatedProduct = new Product
                    {
                        id = productId, // Convert string to int
                        Name = productName,
                        Description = productDescription,
                        Price = productPrice
                    };

                    try
                    {
                        var res = await productService.UpdateProductAsync(updatedProduct);
                        Console.WriteLine(res.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Price. Please enter a valid numeric value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Product Id. Please enter a valid numeric value.");
            }
        }





        public async Task ViewProducts()
        {
            try
            {
                var products = await productService.GetAllProductsAsync();
                foreach (var product in products)
                {
                    await Console.Out.WriteLineAsync($"{product.id} . {product.Name}");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public async Task DeleteProduct()
        {
            await ViewProducts();
            Console.WriteLine("Enter the Id of the Product you want to Delete:");
            var id = Console.ReadLine();

            try
            {
                var res = await productService.DeleteProductAsync(id);
                Console.WriteLine(res.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
        

