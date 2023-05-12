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

namespace HardwareStoreWeb.Pages.ComponentDetails
{
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
    }
}
