using System;
using System.Net;
using System.Web.Mvc;
using Stho.Auth.Apple;
using Stho.Auth.Apple.Models;
using Stho.Auth.WebExample.Models;

namespace Stho.Auth.WebExample.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppleIdService _appleIdService;

        public LoginController(IAppleIdService appleIdService)
        {
            _appleIdService = appleIdService;
        }

        public ActionResult Index() => View();

        public ActionResult SignInWithApple()
        {
            var signInUri = _appleIdService.GetAppleSignInUri("no.stho.client", AuthScope.Email | AuthScope.Name);
            
            HttpContext.Session["state"] = signInUri.State;
            HttpContext.Session["clientId"] = signInUri.Configuration.ClientId;
            
            return Redirect(signInUri.ToString());
        }

        [HttpPost]
        public ActionResult AppleCallback(AppleCallbackRequest request)
        {
            try
            {
                var clientId = HttpContext.Session["clientId"] as string;
                var response = _appleIdService.FetchAccessToken(clientId, request.Code);
                
                return View(new AppleCallbackViewModel(response));
            }
            catch (Exception ex)
            {
                return View(new AppleCallbackViewModel(ex));
            }
        }
    }
}
