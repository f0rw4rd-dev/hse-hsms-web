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

namespace HardwareStoreWeb.Pages.ComponentStorages
{
	public class EditModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public EditModel(HardwareStoreWeb.StoreContext context)
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
			ComponentStorage = componentstorage;
			ViewData["ComponentId"] = new SelectList(_context.Components, "Id", "Id");
			ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Id");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return await OnGetAsync(ComponentStorage.Id);
			}

            var warehouse = await _context.Warehouses.FindAsync(ComponentStorage.WarehouseId);
            if (warehouse == null)
            {
                ViewData["ErrorMessage"] = "Склад с данным ИД не существует!";
                return await OnGetAsync(ComponentStorage.Id);
            }

            var component = await _context.Components.FindAsync(ComponentStorage.ComponentId);
            if (component == null)
            {
                ViewData["ErrorMessage"] = "Комплектующее с данным ИД не существует!";
                return await OnGetAsync(ComponentStorage.Id);
            }

            _context.Attach(ComponentStorage).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ComponentStorageExists(ComponentStorage.Id))
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

		private bool ComponentStorageExists(int id)
		{
			return (_context.ComponentStorages?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
