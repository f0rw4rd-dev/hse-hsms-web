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

namespace HardwareStoreWeb.Pages.Supplies
{
    [Authorize]
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

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "ИД поставщика", "ИД комплектующего", "ИД склада", "Закупочная цена (руб)", "Количество товара (шт)", "Дата поставки" } };
			var cellData = new List<object[]>() { };

			foreach (var supply in _context.Supplies.ToList())
			{
				if (supply == null)
					continue;

				cellData.Add(new object[] 
				{ 
					supply.Id, 
					supply.SupplierId, 
					supply.ComponentId, 
					supply.WarehouseId, 
					supply.SupplyPrice, 
					supply.Amount,
					supply.Date.ToString("dd-MM-yyyy HH:mm") 
				});
			}

			return await ExportHelper.ExportToExcel(this, "Поставки", headerRow, cellData);
		}
	}
}
