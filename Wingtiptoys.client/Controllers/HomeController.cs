using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wingtiptoys.client.Models;
using Wingtiptoys.client.Repository;
using Wingtiptoys.DB.Models;

namespace Wingtiptoys.client.Controllers
{
    public class HomeController : Controller
    {
        // TO DO : Logging needs to be added for the tracking the info, debug, error 

        private readonly ILogger<HomeController> _logger;
        // Instantating Product Repo to be used in the Controller
        private ProductRepository productRepo = new ProductRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // start action for the page to display the car search
        public IActionResult Index()
        {

            //return View();
            return View(productRepo.GetAll());
        }


        // Action to Return Json Result for the Jquery Ajax call to bind on key search
        [HttpPost]
        [ResponseCache(Duration = 0, NoStore = true)]
        public JsonResult Search(string strSearch)
        {
            return Json(JsonConvert.SerializeObject(
                                       from p in productRepo.GetProductsBySearch(strSearch)
                                       select new Product
                                       {
                                           ProductId = p.ProductId,
                                           ProductName = p.ProductName,
                                           Description = p.Description,
                                           ImagePath = p.ImagePath,
                                           UnitPrice = p.UnitPrice
                                       }));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
