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

namespace HardwareStoreWeb.Pages.Suppliers
{
	public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public IList<Supplier> Supplier { get; set; } = default!;

		public Pagination<Supplier> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.Suppliers != null)
			{
				Supplier = await _context.Suppliers.OrderBy(x => x.Id).ToListAsync();

				if (Supplier.Any())
				{
					Pagination = new Pagination<Supplier>(Supplier, pageNumber, 20);
					Supplier = Pagination.Items;
				}
			}
		}
	}
}
