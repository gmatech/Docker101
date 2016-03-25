using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.OptionsModel;
using WebApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ecapp.Controllers
{
    public class ConfigController : Controller
    {
        Config Config { get; }
        
        public ConfigController(IOptions<Config> optionsAccessor)
        {
            Config = optionsAccessor.Value;
        }
        
        public IActionResult Index()
        {
            return View(Config);
        }
    }
}
