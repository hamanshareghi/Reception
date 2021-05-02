using System.Threading.Tasks;
using Data.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace Web.Controllers
{

    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        //[Route("Login")]
        public IActionResult Login(string returnUrl = "/Profile")
        {
            ViewBag.Return = returnUrl;
            return View();
        }

        [HttpPost]
        //[Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(model.PhoneNumber).Result;
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(model.PhoneNumber, model.Password, model.RememberMe,
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                }
                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل شده است";
                    return View(model);
                }
                ModelState.AddModelError(string.Empty, "Login  Error");
                return View();
            }
            return View(model);
        }



        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool roleExist = await _roleManager.RoleExistsAsync("Users");
                if (!roleExist)
                {

                    var role = new ApplicationRole
                    {
                        Name = "Users"
                    };
                    await _roleManager.CreateAsync(role);
                }
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    PhoneNumber = model.UserName,
                    EmailConfirmed = true

                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var rolesResult = await _userManager.AddToRoleAsync(user, "Users");
                    return Redirect("/Profile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
