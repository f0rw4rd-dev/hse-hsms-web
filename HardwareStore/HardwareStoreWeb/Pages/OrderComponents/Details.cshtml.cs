using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.OrderComponents
{
	public class DetailsModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public DetailsModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public OrderComponent OrderComponent { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.OrderComponents == null)
			{
				return NotFound();
			}

			var ordercomponent = await _context.OrderComponents.FirstOrDefaultAsync(m => m.Id == id);
			if (ordercomponent == null)
			{
				return NotFound();
			}
			else
			{
				OrderComponent = ordercomponent;
			}
			return Page();
		}
	}
}
