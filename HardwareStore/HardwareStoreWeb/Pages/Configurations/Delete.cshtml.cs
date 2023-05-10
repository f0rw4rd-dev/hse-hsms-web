using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Configurations
{
	public class DeleteModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DeleteModel(HardwareStoreWeb.StoreContext context)
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
			else
			{
				Configuration = configuration;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Configurations == null)
			{
				return NotFound();
			}
			var configuration = await _context.Configurations.FindAsync(id);

			if (configuration != null)
			{
				Configuration = configuration;
				_context.Configurations.Remove(Configuration);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
