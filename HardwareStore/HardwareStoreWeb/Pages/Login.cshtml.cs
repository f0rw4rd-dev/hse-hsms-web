using HardwareStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using HardwareStoreWeb.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

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
				ViewData["ErrorMessage"] = "������ �� ����� ���� ������!";
				return OnGet();
			}

			var hashedPassword = HashHelper.GetHash(SHA256.Create(), password);
			var user = await _context.Users.Where(x => x.Id == id && x.Password == hashedPassword).FirstOrDefaultAsync();
			if (user == null)
			{
				ViewData["ErrorMessage"] = "������������ � ����� �� � ������� �� ����������!";
				return OnGet();
			}

			user.LastVisitDate = DateTime.UtcNow;

			await _context.SaveChangesAsync();

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Id.ToString())
			};
			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

			return RedirectToPage("./Index");
		}
	}
}
