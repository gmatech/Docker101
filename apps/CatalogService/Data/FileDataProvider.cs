using System.Collections.Generic;
using CatalogService.Data.Entities;

namespace CatalogService.Providers
{
    public class FileDataProvider : IDataProvider
    {
        public FileDataProvider()
        {
        }
        
        public List<Product> GetAllProducts()
        {
            return new List<Product>();
        }
    }
}
