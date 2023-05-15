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

namespace HardwareStoreWeb.Pages.DetailTypes
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
		public DetailType DetailType { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.DetailTypes == null || DetailType == null)
			{
				return OnGet();
			}

            var detailTypeExist = await _context.DetailTypes.Where(x => x.Name == DetailType.Name).AnyAsync();
            if (detailTypeExist)
            {
                ViewData["ErrorMessage"] = "Тип характеристик с таким названием уже существует!";
                return OnGet();
            }

            _context.DetailTypes.Add(DetailType);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
