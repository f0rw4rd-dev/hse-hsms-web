using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Supplies
{
	public class DeleteModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DeleteModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Supply Supply { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Supplies == null)
			{
				return NotFound();
			}

			var supply = await _context.Supplies.FirstOrDefaultAsync(m => m.Id == id);

			if (supply == null)
			{
				return NotFound();
			}
			else
			{
				Supply = supply;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Supplies == null)
			{
				return NotFound();
			}
			var supply = await _context.Supplies.FindAsync(id);

			if (supply != null)
			{
				Supply = supply;
				_context.Supplies.Remove(Supply);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
