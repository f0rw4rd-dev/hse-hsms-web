using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.ComponentTypes
{
	public class EditModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public EditModel(HardwareStoreWeb.StoreContext context)
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
			ComponentType = componenttype;
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(ComponentType).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ComponentTypeExists(ComponentType.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool ComponentTypeExists(int id)
		{
			return (_context.ComponentTypes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
