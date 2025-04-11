using System;
using System.ComponentModel.DataAnnotations;
// For password Encryption
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Facebook.Models.ViewModels
{
   
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; } = "Testing";

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        public string Gender { get; set; }

       [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}