using Entity.Concrete;
using Estate.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Estate.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private UserManager<UserAdmin> _userManager;
		private SignInManager<UserAdmin> _signInManager;

		public AdminController(UserManager<UserAdmin> userManager, SignInManager<UserAdmin> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Login()
		{
			return View(new LoginModel());
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginModel loginModel)
		{
			if (!ModelState.IsValid)
			{
				return View(loginModel);
			}
			var user = await _userManager.FindByNameAsync(loginModel.UserName);
			if (user == null)
			{
				ModelState.AddModelError("", "Information do not match");
			}
			var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

			if (result.Succeeded)
			{
				HttpContext.Session.SetString("Id",user.Id);
				HttpContext.Session.SetString("FullName", user.FullName);

				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			HttpContext.Session.Remove("FullName");
			return RedirectToAction("Login");
		}


	}
}
