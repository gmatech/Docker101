using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.OptionsModel;
using WebApp.Models;
using WebApp.Proxies;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class CatalogController : Controller
    {
        private Config _config;
        private CatalogServiceProxy _catalogServiceProxy { get; set; }
        
        public CatalogController(IOptions<Config> optionsAccessor)
        {
            _config = optionsAccessor.Value;
            _catalogServiceProxy = new CatalogServiceProxy(_config);
        }
        
        public async Task<IActionResult> Index()
        {
            //var products = GetAllProducts();
            
            var products = await _catalogServiceProxy.GetAllProductsAsync();
            
            return View(products);
        }
        
        public IActionResult ConfigTest()
        {
            return View(_config);
        }
        
        // public List<Product> GetAllProducts()
        // {
        //     return new List<Product> {
        //         new Product {Id = 1, Name="Product 1", Price=2.95m},
        //         new Product {Id = 2, Name="Product 2", Price=4.95m}
        //     };
        // }
    }
}
