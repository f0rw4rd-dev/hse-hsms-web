using HardwareStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using HardwareStoreWeb.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HardwareStoreWeb.Pages
{
    public class LoginModel : PageModel
    {
		private readonly HardwareStoreWeb.StoreContext _context;

		public LoginModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync(int id, string password)
		{
			if (_context.Users == null)
			{
				return OnGet();
			}

			if (password == null || password.Length == 0)
			{
				ViewData["ErrorMessage"] = "Пароль не может быть пустым!";
				return OnGet();
			}

			var hashedPassword = HashHelper.GetHash(SHA256.Create(), password);
			var user = await _context.Users.Where(x => x.Id == id && x.Password == hashedPassword).FirstOrDefaultAsync();
			if (user == null)
			{
				ViewData["ErrorMessage"] = "Пользователя с таким ИД и паролем не существует!";
				return OnGet();
			}

			user.LastVisitDate = DateTime.UtcNow;

			await _context.SaveChangesAsync();

			var groupName = user.Group.GetType().GetMember(user.Group.ToString())[0].GetCustomAttribute<DisplayAttribute>()!.Name;

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Id.ToString()),
				new Claim("Group", groupName!)
			};
			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

			return RedirectToPage("./Index");
		}
	}
}
