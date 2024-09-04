using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.DtoLayer.LoginDtos;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebUi.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginUserDto loginUserDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password , false , false);
            if (result.Succeeded) {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
