using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Suppliers
{
	public class DeleteModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DeleteModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Supplier Supplier { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Suppliers == null)
			{
				return NotFound();
			}

			var supplier = await _context.Suppliers.FirstOrDefaultAsync(m => m.Id == id);

			if (supplier == null)
			{
				return NotFound();
			}
			else
			{
				Supplier = supplier;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Suppliers == null)
			{
				return NotFound();
			}
			var supplier = await _context.Suppliers.FindAsync(id);

			if (supplier != null)
			{
				Supplier = supplier;
				_context.Suppliers.Remove(Supplier);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
