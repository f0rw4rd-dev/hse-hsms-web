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

namespace HardwareStoreWeb.Pages.OrderComponents
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<OrderComponent> OrderComponent { get; set; } = default!;

		public Pagination<OrderComponent> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.OrderComponents != null)
			{
				OrderComponent = await _context.OrderComponents
					.OrderBy(x => x.OrderId)
					.ThenBy(x => x.WarehouseId)
					.ThenBy(x => x.ComponentId)
					.Include(o => o.Component)
					.Include(o => o.Order)
					.Include(o => o.Warehouse).ToListAsync();

				if (OrderComponent.Any())
				{
					Pagination = new Pagination<OrderComponent>(OrderComponent, pageNumber, 20);
					OrderComponent = Pagination.Items;
				}
			}
		}
	}
}
