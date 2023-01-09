using System.ComponentModel.DataAnnotations;

namespace DemoStore.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage ="Product Name is required")]
        [Display(Name = "Product Name")]
        [StringLength (100, MinimumLength =3, ErrorMessage = "Product Name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Image URL is required")]
        [Display(Name = "Product Image URL")]
        public string ImageURL { get; set; }
    }
}
