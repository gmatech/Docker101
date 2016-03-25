using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Proxies
{
    public class CatalogServiceProxy
    {
        private Config Config { get; }
        
        public CatalogServiceProxy(Config config)
        {
            Config = config;
        }
    }
}
