using DemoStore.Date.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductsService _service;
        private readonly SignInManager<IdentityUser> _signInManager;

        public StoreController(IProductsService service, SignInManager<IdentityUser> signInManager)
        {
            _service = service;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllProductsAsync();
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllProductsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allProducts.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("Logout")]
        //public ActionResult LogoutFromGoogle()
        //{
        //    //Logout from google

        //    return Redirect("https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=");
        //}
    }
}
