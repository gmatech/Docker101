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
        private readonly IDataProvider _dataProvider;
        
        public ProductsController()
        {
            _dataProvider = new FileDataProvider();
        }
        
        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> Products()
        {
            return _dataProvider.GetAllProducts();
        }
    }
}
