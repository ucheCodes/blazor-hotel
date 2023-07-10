using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppModels
{
    public class Users
    {
        public string Id { get; set; } = "";
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "Invalid email!!! must be in the form abc@xyz.com")]
        public string Email { get; set; } = "";
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must have at least 8 characters, including a letter, number, and special character.")]
        public string Password { get; set; } = "";
        [Required]
        [Compare("Password", ErrorMessage = "Password fields do not match, ensure both fields are the same.")]
        public string Password2 { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = "";
        [Required]
        [RegularExpression(@"^(?:\+?\d{1,3})?(?:0|\d{1,4})\d{10}$",
            ErrorMessage = "Mobile number is invalid")]
        public string Mobile { get; set; } = "";
    }
}
