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

namespace HardwareStoreWeb.Pages.Configurations
{
    [Authorize]
    public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<Configuration> Configuration { get; set; } = default!;

		public Pagination<Configuration> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.Configurations != null)
			{
				Configuration = await _context.Configurations
					.OrderBy(x => x.ConfigurationId)
					.ThenBy(x => x.ComponentId)
					.Include(c => c.Component).ToListAsync();

				if (Configuration.Any())
				{
					Pagination = new Pagination<Configuration>(Configuration, pageNumber, 20);
					Configuration = Pagination.Items;
				}
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "ИД конфигурации", "ИД комплектующего", "Количество" } };
			var cellData = new List<object[]>() { };

			foreach (var configuration in _context.Configurations.ToList())
			{
				if (configuration == null)
					continue;

				cellData.Add(new object[] 
				{ 
					configuration.Id,
					configuration.ConfigurationId,
					configuration.ComponentId, 
					configuration.Amount 
				});
			}

			return await ExportHelper.ExportToExcel(this, "Конфигурации", headerRow, cellData);
		}
	}
}
