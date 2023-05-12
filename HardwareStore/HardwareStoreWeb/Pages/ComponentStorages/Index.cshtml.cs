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

namespace HardwareStoreWeb.Pages.ComponentStorages
{
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
    }
}
