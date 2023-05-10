using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.ComponentTypes
{
	public class DetailsModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DetailsModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public ComponentType ComponentType { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.ComponentTypes == null)
			{
				return NotFound();
			}

			var componenttype = await _context.ComponentTypes.FirstOrDefaultAsync(m => m.Id == id);
			if (componenttype == null)
			{
				return NotFound();
			}
			else
			{
				ComponentType = componenttype;
			}
			return Page();
		}
	}
}
