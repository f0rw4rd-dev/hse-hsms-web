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

namespace HardwareStoreWeb.Pages.Configurations
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
			return Page();
		}

		[BindProperty]
		public Configuration Configuration { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Configurations == null || Configuration == null)
			{
				return OnGet();
			}

            var component = await _context.Warehouses.FindAsync(Configuration.ComponentId);
            if (component == null)
            {
                ViewData["ErrorMessage"] = "Комплектующее с данным ИД не существует!";
                return OnGet();
            }

            var configurationExist = await _context.Configurations.Where(x => x.ConfigurationId == Configuration.ConfigurationId && x.ComponentId == Configuration.ComponentId).AnyAsync();
            if (configurationExist)
            {
                ViewData["ErrorMessage"] = "В данной сборке уже имеется такое комплектующее!";
                return OnGet();
            }

            _context.Configurations.Add(Configuration);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
