using System.Web.Mvc;
using Newtonsoft.Json;
using Stho.Auth.Apple;
using Stho.Auth.WebExample.Models;

namespace Stho.Auth.WebExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppleConfigurationProvider _appleConfigurationProvider;

        public HomeController(IAppleConfigurationProvider appleConfigurationProvider)
        {
            _appleConfigurationProvider = appleConfigurationProvider;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetSomeData(AppleCallbackRequest request)
        {
            return Content(JsonConvert.SerializeObject(request, Formatting.Indented), "application/json");
        }

        public ActionResult Configuration()
        {
            return View(_appleConfigurationProvider.Get());
        }
    }
}