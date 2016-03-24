using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using CatalogService.Data;
using CatalogService.Data.Entities;

namespace CatalogService.Data
{
    public class FileDataProvider : IDataProvider
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products;
            
            using (var fs = new FileStream("/data/app/Products.json", FileMode.Open))
            using (var r = new StreamReader(fs))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            
            return products;
        }
    }
}
