using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.DtoLayer.RegisterDtos;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebUi.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult CreateUser()
		{
			return View();
		}
		[HttpPost]	
		public async Task<IActionResult> CreateUser(CreateRegisterDto createRegisterDto)
		{
			AppUser appUser = new AppUser()
			{
				Name = createRegisterDto.Name,
				Surname = createRegisterDto.Surname,
				UserName = createRegisterDto.UserName,
				Email = createRegisterDto.Email,

			};
			var result =await _userManager.CreateAsync(appUser , createRegisterDto.Password);
			if (result.Succeeded) { 
				return RedirectToAction("Index" , "Default");
			}
			return View();
		}

	}
}
