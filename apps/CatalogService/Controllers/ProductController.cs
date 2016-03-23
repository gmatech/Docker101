using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace CatalogService.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> Products()
        {
            return GetAllProducts();
        }
        
        private IEnumerable<Product> GetAllProducts()
        {
            // var products = new List<Product>
            // {
            //     new Product
            //     {
            //         Id = 1,
            //         Name = "Product 1",
            //         Price = 1.95m
            //     },
            //     new Product
            //     {
            //         Id = 2,
            //         Name = "Product 2",
            //         Price = 2.95m
            //     }
            // };
            
            List<Product> products;
            
            using (var r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            
            return products;
        }
    }
    
    public class Product 
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public decimal Price {get;set;}
    }
}
