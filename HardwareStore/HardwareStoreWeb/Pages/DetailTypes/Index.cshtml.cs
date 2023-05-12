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

namespace HardwareStoreWeb.Pages.DetailTypes
{
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
				DetailType = await _context.DetailTypes.ToListAsync();

				if (DetailType.Any())
				{
					Pagination = new Pagination<DetailType>(DetailType, pageNumber, 20);
					DetailType = Pagination.Items;
				}
			}
		}
	}
}
