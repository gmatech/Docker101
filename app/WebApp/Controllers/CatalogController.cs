using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.OptionsModel;
using WebApp.Models;
using WebApp.Proxies;

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
        
        public async Task<IActionResult> Products()
        {
            var products = await _catalogServiceProxy.GetAllProductsAsync();
            
            return View(products);
        }
        
        public IActionResult ConfigTest()
        {
            return View(_config);
        }
    }
}
