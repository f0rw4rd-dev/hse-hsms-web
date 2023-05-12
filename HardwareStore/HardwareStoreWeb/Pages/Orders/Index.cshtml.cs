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

namespace HardwareStoreWeb.Pages.Orders
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<Order> Order { get; set; } = default!;

		public Pagination<Order> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.Orders != null)
			{
				Order = await _context.Orders.OrderBy(x => x.Id).ToListAsync();

				if (Order.Any())
				{
					Pagination = new Pagination<Order>(Order, pageNumber, 20);
					Order = Pagination.Items;
				}
			}
		}
	}
}
