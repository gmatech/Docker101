using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Config
    {
        public Services Services { get; set; }
    }
    
    public class Services
    {
        public string CatalogService { get; set; }
        public string ShippingService { get; set; }
    }
}
