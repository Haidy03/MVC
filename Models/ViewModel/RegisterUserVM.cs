using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModel
{
    public class RegisterUserVM
    {
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
