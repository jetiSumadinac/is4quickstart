using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identityServer4rawCoding.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<IdentityUser> _signInManager;
        UserManager<IdentityUser> _userManager;
        public AuthController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterVewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = new IdentityUser(vm.Username);
            await _userManager.CreateAsync(user, "password");

            var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                //return Redirect(vm.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {

            }

            return View();
        }

       
        [HttpGet]
        public IActionResult Login(string returnUrl) {
            return View(new LoginVewModel { ReturnUrl = returnUrl});
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginVewModel vm) {
            //here check for model is valid

            var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);
            if (result.Succeeded) 
            {
                //return Redirect(vm.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {

            }

            return View();
        }
    }
}
