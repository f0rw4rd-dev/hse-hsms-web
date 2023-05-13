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

namespace HardwareStoreWeb.Pages.OrderComponents
{
    [Authorize]
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

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "ИД заказа", "ИД склада", "ИД комплектующего", "Цена (руб)", "Количество (шт)", "Часть конфигурации" } };
			var cellData = new List<object[]>() { };

			foreach (var orderComponent in _context.OrderComponents.ToList())
			{
				if (orderComponent == null)
					continue;

				cellData.Add(new object[] 
				{ 
					orderComponent.Id, 
					orderComponent.OrderId, 
					orderComponent.WarehouseId, 
					orderComponent.ComponentId, 
					orderComponent.Price, 
					orderComponent.Amount, 
					orderComponent.IsPartOfConfiguration 
				});
			}

			return await ExportHelper.ExportToExcel(this, "Содержимое заказов", headerRow, cellData);
		}
	}
}
