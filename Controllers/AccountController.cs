using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager= _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM userVM) 
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userVM.UserName;
                user.Address = userVM.Address;
                user.PasswordHash = userVM.Password;

                IdentityResult res = await userManager.CreateAsync(user,userVM.Password);

                if (res.Succeeded)
                {
                  await signInManager.SignInAsync(user, false);
                    return RedirectToAction("getall", "Department");
                }
                else { 
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View("Register", userVM);
                }

                
            }
            return View("Register",userVM);
        }

        public async Task<IActionResult> Signout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM userVM)
        {
            if (ModelState.IsValid) {
              ApplicationUser user= await userManager.FindByNameAsync(userVM.UserName);
                if (user != null) { 
                   bool found= await userManager.CheckPasswordAsync(user, userVM.Password);
                    if (found) {
                       await signInManager.SignInAsync(user, userVM.RememberMe);
                        return RedirectToAction("getall", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
            }
            return View("Login",userVM);
        }
    }
}
