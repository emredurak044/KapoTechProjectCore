using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using KapoTechProjectCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Controllers
{        [AllowAnonymous]

    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public LoginController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }
        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                UserName = p.Username,
                Email = p.EMail
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                var addRoleToUser = await _userManager.AddToRoleAsync(appUser, "Member");
                if (result.Succeeded && addRoleToUser.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            Context c = new Context();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, p.RememberMe, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adınızı yada Şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.!");
                }
            }
            return View();
        }
    }
}
