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

namespace HardwareStoreWeb.Pages.ComponentStorages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HardwareStoreWeb.StoreContext _context;

        public IndexModel(HardwareStoreWeb.StoreContext context)
        {
            _context = context;
        }

        public IList<ComponentStorage> ComponentStorage { get; set; } = default!;

		public Pagination<ComponentStorage> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
        {
            if (_context.ComponentStorages != null)
            {
                ComponentStorage = await _context.ComponentStorages
                    .OrderBy(x => x.WarehouseId)
                    .ThenBy(x => x.ComponentId)
                    .Include(c => c.Component)
                    .Include(c => c.Warehouse).ToListAsync();

				if (ComponentStorage.Any())
				{
					Pagination = new Pagination<ComponentStorage>(ComponentStorage, pageNumber, 20);
					ComponentStorage = Pagination.Items;
				}
			}
        }

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "ИД склада", "ИД комплектующего", "Цена (руб)", "Количество (шт)" } };
			var cellData = new List<object[]>() { };

			foreach (var componentStorage in _context.ComponentStorages.ToList())
			{
				if (componentStorage == null)
					continue;

				cellData.Add(new object[] 
				{ 
					componentStorage.Id,
					componentStorage.WarehouseId, 
					componentStorage.ComponentId,
					componentStorage.Price,
					componentStorage.Amount 
				});
			}

			return await ExportHelper.ExportToExcel(this, "Учет комплектующих", headerRow, cellData);
		}
	}
}
