using System.ComponentModel.DataAnnotations;

namespace ProjectOne.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
    }
}
