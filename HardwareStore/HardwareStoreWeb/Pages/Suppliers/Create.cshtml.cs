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

namespace HardwareStoreWeb.Pages.Suppliers
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
		public Supplier Supplier { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Suppliers == null || Supplier == null)
			{
				return OnGet();
			}

            var supplierExist = await _context.Suppliers.Where(x => x.Name == Supplier.Name).AnyAsync();
            if (supplierExist)
            {
                ViewData["ErrorMessage"] = "Поставщик с таким названием уже существует!";
                return OnGet();
            }

            _context.Suppliers.Add(Supplier);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
