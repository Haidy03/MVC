using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModel
{
    public class LoginUserVM
    {
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
