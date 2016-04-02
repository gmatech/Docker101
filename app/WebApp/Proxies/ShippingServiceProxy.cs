using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using WebApp.Models;

namespace WebApp.Proxies
{
    public class ShippingServiceProxy
    {
        private HttpClient _httpClient;
        
        public ShippingServiceProxy(Config config)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config.Services.ShippingService)
            };
        }
        
        public async Task<List<ShippingRate>> GetAllShippingRatesAsync()
        {
            var response = await _httpClient.GetAsync("Shipping/Rates");
            var rates = await response.Content.ReadAsAsync<List<ShippingRate>>();
            
            return rates;
        }
    }
}
