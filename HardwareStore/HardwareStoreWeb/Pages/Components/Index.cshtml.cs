using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;
using HardwareStoreWeb.Utilities;
using System.Drawing.Printing;
using System.ComponentModel.DataAnnotations;

namespace HardwareStoreWeb.Pages.Components
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<Component> Component { get; set; } = default!;

		public Pagination<Component> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.Components != null)
			{
				Component = await _context.Components
					.OrderBy(x => x.Id)
					.Include(c => c.ComponentType).ToListAsync();

				if (Component.Any())
				{
					Pagination = new Pagination<Component>(Component, pageNumber, 20);
					Component = Pagination.Items;
				}
			}
		}
	}
}
