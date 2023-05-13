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
using Microsoft.AspNetCore.Authorization;

namespace HardwareStoreWeb.Pages.Orders
{
    [Authorize]
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

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "Дата заказа", "Статус заказа" } };
			var cellData = new List<object[]>() { };

			foreach (var order in _context.Orders.ToList())
			{
				if (order == null)
					continue;

				cellData.Add(new object[] 
				{ 
					order.Id, 
					order.Date.ToString("dd-MM-yyyy HH:mm"), 
					order.Status 
				});
			}

			return await ExportHelper.ExportToExcel(this, "Заказы", headerRow, cellData);
		}
	}
}
