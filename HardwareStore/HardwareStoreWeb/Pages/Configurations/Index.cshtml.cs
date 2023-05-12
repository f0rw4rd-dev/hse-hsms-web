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

namespace HardwareStoreWeb.Pages.Configurations
{
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
	}
}
