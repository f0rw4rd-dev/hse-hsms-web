using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.ComponentStorages
{
	public class DeleteModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DeleteModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public ComponentStorage ComponentStorage { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.ComponentStorages == null)
			{
				return NotFound();
			}

			var componentstorage = await _context.ComponentStorages.FirstOrDefaultAsync(m => m.Id == id);

			if (componentstorage == null)
			{
				return NotFound();
			}
			else
			{
				ComponentStorage = componentstorage;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.ComponentStorages == null)
			{
				return NotFound();
			}
			var componentstorage = await _context.ComponentStorages.FindAsync(id);

			if (componentstorage != null)
			{
				ComponentStorage = componentstorage;
				_context.ComponentStorages.Remove(ComponentStorage);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
