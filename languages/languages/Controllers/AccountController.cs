using languages.Models;
using languages.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace languages.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager ;

        public AccountController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {

            this.signInManager = signInManager;
            this.userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task< IActionResult> Register(registervm logIn)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Email = logIn.Email;
                applicationUser.UserName = logIn.Name;
                applicationUser.PasswordHash = logIn.Password;
                IdentityResult result = await userManager.CreateAsync(applicationUser,logIn.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("Password", erroritem.Description);
                    }
                }

            }
            return View(logIn);
        }
        [HttpGet]
        public IActionResult login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(LogIn loginVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = await userManager.FindByNameAsync(loginVm.Name);
                if (applicationUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(applicationUser, loginVm.Password);
                    if (found == true)
                    {
                        await signInManager.SignInAsync(applicationUser, loginVm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Name Or Password Wrong");
            }
            return View(loginVm);
        }
        public async Task<IActionResult> logout(LogIn vm)
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }


    }
}
