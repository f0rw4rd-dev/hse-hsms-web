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

namespace HardwareStoreWeb.Pages.Supplies
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<Supply> Supply { get; set; } = default!;

		public Pagination<Supply> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.Supplies != null)
			{
				Supply = await _context.Supplies
				.Include(s => s.Component)
				.Include(s => s.Supplier)
				.Include(s => s.Warehouse).ToListAsync();

				if (Supply.Any())
				{
					Pagination = new Pagination<Supply>(Supply, pageNumber, 20);
					Supply = Pagination.Items;
				}
			}
		}
	}
}
