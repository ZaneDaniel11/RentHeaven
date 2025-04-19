using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Heaven.Models.Account
{
    public class RegisterViewModel
        {
            [Required]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(6)]
            public string Password { get; set; }

            [Compare("Password")]
            public string ConfirmPassword { get; set; }

            public string PhoneNumber { get; set; }

            public string Bio { get; set; }

            public IFormFile ProfilePicture { get; set; } // for image upload (optional)
        }

}