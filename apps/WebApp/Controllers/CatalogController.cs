using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class CatalogController : Controller
    {
        public CatalogController()
        {
            
        }
        
        public IActionResult Index()
        {
            var products = GetAllProducts();
            
            return View(products);
        }
        
        public List<Product> GetAllProducts()
        {
            return new List<Product> {
                new Product {Id = 1, Name="Product 1", Price=2.95m},
                new Product {Id = 2, Name="Product 2", Price=4.95m}
            };
        }
    }
}
