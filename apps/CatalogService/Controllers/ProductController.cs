using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System.IO;
using CatalogService.Data;
using CatalogService.Data.Entities;

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
            
            using (var fs = new FileStream("/data/Products.json", FileMode.Open))
            using (var r = new StreamReader(fs))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            
            return products;
        }
    }
}
