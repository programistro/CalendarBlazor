using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Calendar.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("google-login")]
        public async Task<ActionResult> Google()
        {
            var prop = new AuthenticationProperties
            {
                RedirectUri = "/"
            };
            return Challenge(prop, GoogleDefaults.AuthenticationScheme);
        }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [AllowAnonymous]
        [HttpGet("signout")]
        public async Task signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var prop = new AuthenticationProperties
            {
                RedirectUri = "/logout-complete"
            };
        }

        [HttpGet("logout-complete")]
        [AllowAnonymous]
        public string logoutComplete()
        {
            return "logout-complete";
        }
    }
}
