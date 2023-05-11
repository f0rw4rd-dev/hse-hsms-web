using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.ComponentStorages
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
			ViewData["ComponentId"] = new SelectList(_context.Components, "Id", "Id");
			ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Id");
			return Page();
		}

		[BindProperty]
		public ComponentStorage ComponentStorage { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.ComponentStorages == null || ComponentStorage == null)
			{
				return OnGet();
			}

			var warehouse = await _context.Warehouses.FindAsync(ComponentStorage.WarehouseId);
			if (warehouse == null)
			{
				ViewData["ErrorMessage"] = "Склад с данным ИД не существует!";
                return OnGet();
            }

            var component = await _context.Components.FindAsync(ComponentStorage.ComponentId);
            if (component == null)
            {
                ViewData["ErrorMessage"] = "Комплектующее с данным ИД не существует!";
				return OnGet();
            }

            _context.ComponentStorages.Add(ComponentStorage);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
