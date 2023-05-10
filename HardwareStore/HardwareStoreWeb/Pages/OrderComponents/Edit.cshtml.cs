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

namespace HardwareStoreWeb.Pages.OrderComponents
{
	public class EditModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public EditModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public OrderComponent OrderComponent { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.OrderComponents == null)
			{
				return NotFound();
			}

			var ordercomponent = await _context.OrderComponents.FirstOrDefaultAsync(m => m.Id == id);
			if (ordercomponent == null)
			{
				return NotFound();
			}
			OrderComponent = ordercomponent;
			ViewData["ComponentId"] = new SelectList(_context.Components, "Id", "Id");
			ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
			ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Id");
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

			_context.Attach(OrderComponent).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!OrderComponentExists(OrderComponent.Id))
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

		private bool OrderComponentExists(int id)
		{
			return (_context.OrderComponents?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
