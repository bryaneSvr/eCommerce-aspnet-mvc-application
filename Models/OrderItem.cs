using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStore.Models
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public long OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
