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
            var signInUri = _appleIdService.GetAppleSignInUri("com.your.client", AuthScope.Email | AuthScope.Name);
            
            // TODO: save state to check when getting reply from apple  
            // signInUri.State
            
            return Redirect(signInUri.ToString());
        }

        [HttpPost]
        public ActionResult AppleCallback(AppleCallbackRequest request)
        {
            try
            {
                // TODO: compare states  
                // request.State == signInUri.State
                
                var response = _appleIdService.FetchAccessToken("com.your.client", request.Code);
                
                return View(new AppleCallbackViewModel(response));
            }
            catch (Exception ex)
            {
                return View(new AppleCallbackViewModel(ex));
            }
        }
    }
}
