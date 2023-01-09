using System.ComponentModel.DataAnnotations;

namespace DemoStore.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public long Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string ShoppingCartId { get;set; }
    }
}
