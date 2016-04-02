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
    public class ShippingController : Controller
    {
        private Config _config;
        private ShippingServiceProxy _shippingServiceProxy { get; set; }
        
        public ShippingController(IOptions<Config> optionsAccessor)
        {
            _config = optionsAccessor.Value;
            _shippingServiceProxy = new ShippingServiceProxy(_config);
        }
        
        [Route("Shipping/Rates")]
        public async Task<IActionResult> Index()
        {
            var rates = await _shippingServiceProxy.GetAllShippingRatesAsync();
            
            return View(rates);
        }
        
        public IActionResult ConfigTest()
        {
            return View(_config);
        }
    }
}
