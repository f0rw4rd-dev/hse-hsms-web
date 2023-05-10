using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.DetailTypes
{
	public class DetailsModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DetailsModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public DetailType DetailType { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.DetailTypes == null)
			{
				return NotFound();
			}

			var detailtype = await _context.DetailTypes.FirstOrDefaultAsync(m => m.Id == id);
			if (detailtype == null)
			{
				return NotFound();
			}
			else
			{
				DetailType = detailtype;
			}
			return Page();
		}
	}
}
