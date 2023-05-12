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

namespace HardwareStoreWeb.Pages.Warehouses
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<Warehouse> Warehouse { get; set; } = default!;

		public Pagination<Warehouse> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.Warehouses != null)
			{
				Warehouse = await _context.Warehouses.OrderBy(x => x.Id).ToListAsync();

				if (Warehouse.Any())
				{
					Pagination = new Pagination<Warehouse>(Warehouse, pageNumber, 20);
					Warehouse = Pagination.Items;
				}
			}
		}
	}
}
