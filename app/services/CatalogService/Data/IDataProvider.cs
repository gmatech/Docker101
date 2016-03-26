using System.Collections.Generic;
using CatalogService.Data.Entities;

namespace CatalogService.Data
{
    public interface IDataProvider
    {
        List<Product> GetAllProducts();
    }
}
