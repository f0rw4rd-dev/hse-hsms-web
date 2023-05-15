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

namespace HardwareStoreWeb.Pages.Configurations
{
	public class EditModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public EditModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Configuration Configuration { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Configurations == null)
			{
				return NotFound();
			}

			var configuration = await _context.Configurations.FirstOrDefaultAsync(m => m.Id == id);
			if (configuration == null)
			{
				return NotFound();
			}
			Configuration = configuration;
			ViewData["ComponentId"] = new SelectList(_context.Components, "Id", "Id");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return await OnGetAsync(Configuration.Id);
            }

            var component = await _context.Warehouses.FindAsync(Configuration.ComponentId);
            if (component == null)
            {
                ViewData["ErrorMessage"] = "Комплектующее с данным ИД не существует!";
                return await OnGetAsync(Configuration.Id);
            }

            var configurationExist = await _context.Configurations.Where(x => x.ConfigurationId == Configuration.ConfigurationId && x.ComponentId == Configuration.ComponentId && x.Id != Configuration.Id).AnyAsync();
            if (configurationExist)
            {
                ViewData["ErrorMessage"] = "В данной сборке уже имеется такое комплектующее!";
                return await OnGetAsync(Configuration.Id);
            }

            _context.Attach(Configuration).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ConfigurationExists(Configuration.Id))
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

		private bool ConfigurationExists(int id)
		{
			return (_context.Configurations?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
