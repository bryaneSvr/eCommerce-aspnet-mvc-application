using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DemoStore.Date.ViewModels
{
    public class LogInViewModel
    {
        [Display(Name ="Email address")]
        [Required(ErrorMessage ="Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

        public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    }
}
