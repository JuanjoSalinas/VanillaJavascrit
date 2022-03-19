 using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanillaJavascript.Models;

namespace VanillaJavascript.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        //Get api/values
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.CrudVanillaJsContext db= new Models.CrudVanillaJsContext()) 
            {
                var lst = (from d in db.Personas
                          select d).ToList();

                return Json(lst);

            }
        }
    }
}