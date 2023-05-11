﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Supplies
{
	public class EditModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public EditModel(HardwareStoreWeb.StoreContext context)
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
			Supply = supply;
			ViewData["ComponentId"] = new SelectList(_context.Components, "Id", "Id");
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Id");
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

			_context.Attach(Supply).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SupplyExists(Supply.Id))
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

		private bool SupplyExists(int id)
		{
			return (_context.Supplies?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}