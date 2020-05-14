using System.Web.Mvc;
using Newtonsoft.Json;
using Stho.Auth.Apple;
using Stho.Auth.WebExample.Models;

namespace Stho.Auth.WebExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppleConfigurationProvider _appleConfigurationProvider;
        private readonly IAppleClientSecretGeneratorFactory _appleClientSecretGeneratorFactory;

        public HomeController(
            IAppleConfigurationProvider appleConfigurationProvider, 
            IAppleClientSecretGeneratorFactory appleClientSecretGeneratorFactory)
        {
            _appleConfigurationProvider = appleConfigurationProvider;
            _appleClientSecretGeneratorFactory = appleClientSecretGeneratorFactory;
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
    }
}