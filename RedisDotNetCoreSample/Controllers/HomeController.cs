using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisDotNetCoreSample.Models;

namespace RedisDotNetCoreSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        public HomeController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public IActionResult Index()
        {

            _distributedCache.SetString("helloFromRedis", "world");
            

            return View();
        }

        public IActionResult Privacy()
        {
            var valueFromRedis = _distributedCache.GetString("helloFromRedis");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
