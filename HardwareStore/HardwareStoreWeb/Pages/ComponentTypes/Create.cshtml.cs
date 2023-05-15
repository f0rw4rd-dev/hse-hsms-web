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

namespace HardwareStoreWeb.Pages.ComponentTypes
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
		public ComponentType ComponentType { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.ComponentTypes == null || ComponentType == null)
			{
				return OnGet();
			}

			var componentTypeExist = await _context.ComponentTypes.Where(x => x.Name == ComponentType.Name).AnyAsync();
			if (componentTypeExist)
			{
				ViewData["ErrorMessage"] = "Категория с таким названием уже существует!";
                return OnGet();
            }

			_context.ComponentTypes.Add(ComponentType);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
