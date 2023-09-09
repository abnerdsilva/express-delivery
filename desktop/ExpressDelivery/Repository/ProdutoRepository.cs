using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using MySqlConnector;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    public class ProdutoRepository
    {
        public string Message = "";

        private readonly MySqlCommand _cmd = new MySqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private MySqlDataReader _dr;
        
        public async Task<List<Product>> LoadAll()
        {
            var products = new List<Product>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + "/v1/products").Result;
                var result = await response.Content.ReadAsStringAsync();

                var productsJson = JsonConvert.DeserializeObject<List<Product>>(result);
                if (productsJson == null)
                {
                    throw new Exception("falha na conversão dos produtos");
                }

                products.AddRange(productsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return products;
        }

        public async Task<List<Product>> LoadByName(string name)
        {
            List<Product> products = new List<Product>();

            try
            {
                var response = ConfigHttp.client.GetAsync($"{ConfigHttp.BaseUrl}/v1/products?name={name}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var productsJson = JsonConvert.DeserializeObject<List<Product>>(result);
                if (productsJson == null)
                {
                    throw new Exception("falha na conversão dos produtos");
                }

                products.AddRange(productsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return products;
        }

        public async Task<List<Product>> LoadById(string id)
        {
            var products = new List<Product>();

            try
            {
                var response = ConfigHttp.client.GetAsync($"{ConfigHttp.BaseUrl}/v1/product/{id}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var productsJson = JsonConvert.DeserializeObject<Product>(result);
                if (productsJson == null)
                {
                    return products;
                }

                products.Add(productsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return products;
        }
        
        public async Task<Product> LastProductId()
        {
            var product = new Product();

            try
            {
                var response = ConfigHttp.client.GetAsync($"{ConfigHttp.BaseUrl}/v1/product?mode=lastProduct").Result;
                var result = await response.Content.ReadAsStringAsync();

                var productJson = JsonConvert.DeserializeObject<Product>(result);
                if (productJson == null)
                {
                    return product;
                }

                product = productJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return product;
        }
        
        public async Task<Product> Create(Product product)
        {
            Product newProduct;
            try
            {
                var json = JsonConvert.SerializeObject(product);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
            
                var response = ConfigHttp.client.PostAsync($"{ConfigHttp.BaseUrl}/v1/product", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var productJson = JsonConvert.DeserializeObject<Product>(result);
                if (productJson == null)
                {
                    return null;
                }

                newProduct = productJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }
            
            return newProduct;
        }

        public async Task<Product> Update(Product product)
        {
            Product editedProduct;

            try
            {
                var json = JsonConvert.SerializeObject(product);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
            
                var response = ConfigHttp.client.PutAsync($"{ConfigHttp.BaseUrl}/v1/product/{product.Uid}", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var productJson = JsonConvert.DeserializeObject<Product>(result);
                if (productJson == null)
                {
                    return null;
                }

                editedProduct = productJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return editedProduct;
        }
    }
}