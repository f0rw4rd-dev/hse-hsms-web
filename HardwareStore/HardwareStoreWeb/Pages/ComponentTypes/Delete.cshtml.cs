using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.ComponentTypes
{
	public class DeleteModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DeleteModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public ComponentType ComponentType { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.ComponentTypes == null)
			{
				return NotFound();
			}

			var componenttype = await _context.ComponentTypes.FirstOrDefaultAsync(m => m.Id == id);

			if (componenttype == null)
			{
				return NotFound();
			}
			else
			{
				ComponentType = componenttype;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.ComponentTypes == null)
			{
				return NotFound();
			}
			var componenttype = await _context.ComponentTypes.FindAsync(id);

			if (componenttype != null)
			{
				ComponentType = componenttype;
				_context.ComponentTypes.Remove(ComponentType);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
