using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using WebApp.Models;

namespace WebApp.Proxies
{
    public class CatalogServiceProxy
    {
        private HttpClient _httpClient;
        
        public CatalogServiceProxy(Config config)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config.Services.CatalogService)
            };
        }
        
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("Products");
            var products = await response.Content.ReadAsAsync<List<Product>>();
            
            return products;
        }
    }
}
