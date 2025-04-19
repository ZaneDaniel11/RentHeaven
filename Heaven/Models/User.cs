using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heaven.Models
{
   public class User
        {
            public int UserID { get; set; }

            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            public string PasswordHash { get; set; }

            public string PhoneNumber { get; set; }

            public string ProfilePictureUrl { get; set; }

            public string Bio { get; set; }

            public DateTime CreatedAt { get; set; }

            public bool IsHost { get; set; } // Maps to SQLite INTEGER (0 = false, 1 = true)
        }
}