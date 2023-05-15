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

namespace HardwareStoreWeb.Pages.DetailTypes
{
    [Authorize]
    public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<DetailType> DetailType { get; set; } = default!;

		public Pagination<DetailType> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.DetailTypes != null)
			{
				DetailType = await _context.DetailTypes.OrderBy(x => x.Id).ToListAsync();

				if (DetailType.Any())
				{
					Pagination = new Pagination<DetailType>(DetailType, pageNumber, 20);
					DetailType = Pagination.Items;
				}
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "Название" } };
			var cellData = new List<object[]>() { };

			foreach (var detailType in _context.DetailTypes.ToList())
			{
				if (detailType == null)
					continue;

				cellData.Add(new object[] 
				{ 
					detailType.Id, 
					detailType.Name 
				});
			}

			return await ExportHelper.ExportToExcel(this, "Типы характеристик комплектующих", headerRow, cellData);
		}
	}
}
