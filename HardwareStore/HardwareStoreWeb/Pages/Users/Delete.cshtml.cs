﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Users
{
	public class DeleteModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DeleteModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public new User User { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

			if (user == null)
			{
				return NotFound();
			}
			else
			{
				User = user;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}
			var user = await _context.Users.FindAsync(id);

			if (user != null)
			{
				User = user;
				_context.Users.Remove(User);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
