using DemoStore.Date.Cart;
using DemoStore.Date.Services;
using DemoStore.Date.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly SignInManager<IdentityUser> _signInManager;

        public OrdersController(IProductsService productsService, ShoppingCart shoppingCart, SignInManager<IdentityUser> signInManager)
        {
            _productsService= productsService;
            _shoppingCart= shoppingCart;
            _signInManager= signInManager;
        }

        public IActionResult ShoppingCart()
        {
            var item = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems= item;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(long id)
        {
            var item = await _productsService.GetProductAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(long id)
        {
            var item = await _productsService.GetProductAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Store");
        }
    }
}
