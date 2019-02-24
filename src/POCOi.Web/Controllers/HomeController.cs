using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POCOi.Web.Models;

namespace POCOi.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Pending", Value = "0" });
            li.Add(new SelectListItem { Text = "Shipped", Value = "1" });
            li.Add(new SelectListItem { Text = "Cancelled", Value = "2" });
            ViewData["status"] = li;

            //Esta parte sai depois do refactor
            List<SelectListItem> liOrders = new List<SelectListItem>();
            liOrders.Add(new SelectListItem { Text = "105", Value = "0" });
            liOrders.Add(new SelectListItem { Text = "44", Value = "1" });
            liOrders.Add(new SelectListItem { Text = "101", Value = "2" });
            liOrders.Add(new SelectListItem { Text = "1", Value = "3" });
            liOrders.Add(new SelectListItem { Text = "10", Value = "4" });
            liOrders.Add(new SelectListItem { Text = "16", Value = "5" });
            ViewData["orders"] = liOrders;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
