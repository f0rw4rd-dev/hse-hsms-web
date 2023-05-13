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

namespace HardwareStoreWeb.Pages.ComponentDetails
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HardwareStoreWeb.StoreContext _context;

        public IndexModel(HardwareStoreWeb.StoreContext context)
        {
            _context = context;
        }

        public IList<ComponentDetail> ComponentDetail { get; set; } = default!;

		public Pagination<ComponentDetail> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
        {
            if (_context.ComponentDetails != null)
            {
                ComponentDetail = await _context.ComponentDetails
                    .OrderBy(x => x.ComponentId)
                    .ThenBy(x => x.DetailTypeId)
                    .Include(c => c.Component)
                    .Include(c => c.DetailType).ToListAsync();

                if (ComponentDetail.Any())
                {
					Pagination = new Pagination<ComponentDetail>(ComponentDetail, pageNumber, 20);
					ComponentDetail = Pagination.Items;
				}
			}
        }

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "ИД комплектующего", "ИД характеристики", "Название характеристики", "Значение" } };
			var cellData = new List<object[]>() { };

			foreach (var componentDetail in _context.ComponentDetails.ToList())
			{
				if (componentDetail == null)
					continue;

				cellData.Add(new object[] 
                { 
                    componentDetail.Id, 
                    componentDetail.ComponentId, 
                    componentDetail.DetailTypeId, 
                    componentDetail.DetailType!.Name, 
                    componentDetail.Value 
                });
			}

			return await ExportHelper.ExportToExcel(this, "Характеристики комплектующих", headerRow, cellData);
		}
	}
}
