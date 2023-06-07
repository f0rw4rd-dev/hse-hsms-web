using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreWeb.Pages.Warehouses
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
			return Page();
		}

		[BindProperty]
		public Warehouse Warehouse { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Warehouses == null || Warehouse == null)
			{
				return OnGet();
			}

            var warehouseExist = await _context.Warehouses.Where(x => x.City == Warehouse.City && x.Street == Warehouse.Street && x.House == Warehouse.House).AnyAsync();
            if (warehouseExist)
            {
                ViewData["ErrorMessage"] = "Склад с таким адресом уже существует!";
                return OnGet();
            }

            _context.Warehouses.Add(Warehouse);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
