using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Warehouses
{
	public class DeleteModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DeleteModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Warehouse Warehouse { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Warehouses == null)
			{
				return NotFound();
			}

			var warehouse = await _context.Warehouses.FirstOrDefaultAsync(m => m.Id == id);

			if (warehouse == null)
			{
				return NotFound();
			}
			else
			{
				Warehouse = warehouse;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Warehouses == null)
			{
				return NotFound();
			}
			var warehouse = await _context.Warehouses.FindAsync(id);

			if (warehouse != null)
			{
				Warehouse = warehouse;
				_context.Warehouses.Remove(Warehouse);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
