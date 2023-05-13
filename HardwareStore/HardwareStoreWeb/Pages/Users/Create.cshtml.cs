using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;
using HardwareStoreWeb.Utilities;
using System.Security.Cryptography;

namespace HardwareStoreWeb.Pages.Users
{
	public class CreateModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public CreateModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public new User User { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Users == null || User == null)
			{
				return OnGet();
			}

			User.RegistrationDate = DateTime.UtcNow;
			User.LastVisitDate = DateTime.UtcNow;
			User.Password = HashHelper.GetHash(SHA256.Create(), User.Password);

			_context.Users.Add(User);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
