using DemoStore.Date.Services;
using DemoStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProductsController(IProductsService service, SignInManager<IdentityUser> signInManager)
        {
            _service = service;    
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllProductsAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Price,ImageURL")]Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _service.AddAsync(product);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(long id)
        {
            var produtDetails = await _service.GetProductAsync(id);

            if (produtDetails == null) return View("NotFound");

            return View(produtDetails);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var produtDetails = await _service.GetProductAsync(id);

            if (produtDetails == null) return View("NotFound");
            return View(produtDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( long id, [Bind("Id,Name,Price,ImageURL")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            await _service.UpdateAsync(id, product);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var produtDetails = await _service.GetProductAsync(id);

            if (produtDetails == null) return View("NotFound");
            return View(produtDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var produtDetails = await _service.GetProductAsync(id);

            if (produtDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Store");
        }
    }
}
