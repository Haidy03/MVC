using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ApplicationUser: IdentityUser
    {
      
        public string? Address { get; set; }
    }
}
