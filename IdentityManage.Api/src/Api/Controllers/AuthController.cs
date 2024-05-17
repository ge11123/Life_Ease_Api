using IdentityManage.src.Domain;
using IdentityManage.src.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManage.src.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel model)
		{
			var user = new ApplicationUser
			{
				UserName = model.Username,
				Email = model.Email,
				FirstName = model.FirstName, // 确保包含 FirstName
				LastName = model.LastName // 确保包含 LastName
			};
			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				return Ok(new { Message = "User registered successfully" });
			}
			return BadRequest(result.Errors);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel model)
		{
			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				return Ok(new { Message = "User logged in successfully" });
			}
			return Unauthorized();
		}
	}
	public class RegisterModel
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; } // 添加 FirstName 字段
		public string LastName { get; set; } // 添加 LastName 字段
	}

	public class LoginModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}


