using System.ComponentModel.DataAnnotations;

namespace ProjectOne.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
