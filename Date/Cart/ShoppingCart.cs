using DemoStore.Migrations;
using DemoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStore.Date.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context= context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session= services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }

        public void AddItemToCart(Product product)
        {
            var shoppingCartItem = _context.ShopingCartItems.FirstOrDefault(x => x.Product.Id == product.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1
                };

                _context.ShopingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Product product)
        {
            var shoppingCartItem = _context.ShopingCartItems.FirstOrDefault(x => x.Product.Id == product.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                }
                else
                {
                    _context.ShopingCartItems.Remove(shoppingCartItem);

                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShopingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Include(x => x.Product).ToList());
        }

        public decimal GetShoppingCartTotal() 
            => _context.ShopingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
            .Select(x => x.Product.Price * x.Quantity).Sum();

    }
}
