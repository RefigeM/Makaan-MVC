using Makaan2.Extentions;
using Makaan2.Models;
using Makaan2.Models.Enums;
using Makaan2.ViewModels.AuthsVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Makaan2.Controllers
{
	public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<IdentityRole> _roleManager) : Controller
	{

		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM vm)
		{
			if (!ModelState.IsValid) return View();
			AppUser user = new AppUser
			{
				Fullname = vm.Fullname,
				UserName = vm.Username,
				Email = vm.Email
			};
			var result = await _userManager.CreateAsync(user, vm.Password);
			if (!result.Succeeded)
			{
				foreach (var err in result.Errors)
				{
					ModelState.AddModelError("", err.Description);
				}
				return View();
			}
			var roleResult = await _userManager.AddToRoleAsync(user, nameof(Roles.User));
			if (!roleResult.Succeeded)
			{
				foreach (var err in roleResult.Errors)
				{
					ModelState.AddModelError("", err.Description);
				}
				return View();
			}
			return Redirect(nameof(Login));
		}
		public IActionResult Login()
		{
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM vm)
		{
			if (!ModelState.IsValid) return View();
			AppUser? user = null;
			if (vm.UsernameOrEmail.Contains("@"))
				user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
			else
				user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
			if (user is null)
			{
				ModelState.AddModelError("", "username or email not found");
				return View();
			}
			var result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true);
			if (!result.Succeeded)
			{
				if (result.IsLockedOut)
					ModelState.AddModelError("", "you're logouted");
				if (result.IsNotAllowed)
					ModelState.AddModelError("", "username or email not found");
				return View();
			}
			return RedirectToAction("Index", "Home");

		}
		public async Task<IActionResult> CreateRolesMethod()
		{
			foreach (Roles item in Enum.GetValues(typeof(Roles)))
			{
				await _roleManager.CreateAsync(new IdentityRole(item.GetRoles()));
			}
			return Ok();
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Index));
		}


	}
}
