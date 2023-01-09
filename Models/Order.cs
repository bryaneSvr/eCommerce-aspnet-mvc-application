using System.ComponentModel.DataAnnotations;

namespace DemoStore.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        public string Email { get; set; }

        public long UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
