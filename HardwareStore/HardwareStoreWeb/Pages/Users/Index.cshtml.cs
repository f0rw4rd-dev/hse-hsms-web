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

namespace HardwareStoreWeb.Pages.Users
{
    [Authorize]
    public class IndexModel : PageModel
	{
		private readonly HardwareStoreWeb.StoreContext _context;

		public IndexModel(HardwareStoreWeb.StoreContext context)
		{
			_context = context;
		}

		public new IList<User> User { get; set; } = default!;

		public Pagination<User> Pagination { get; set; } = default!;

		public async Task OnGetAsync([FromQuery] int pageNumber = 1)
		{
			if (_context.Users != null)
			{
				User = await _context.Users.OrderBy(x => x.Id).ToListAsync();

				if (User.Any())
				{
					Pagination = new Pagination<User>(User, pageNumber, 20);
					User = Pagination.Items;
				}
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var headerRow = new List<string[]>() { new string[] { "ИД", "Группа прав", "Дата последнего входа", "Дата регистрации" } };
			var cellData = new List<object[]>() { };

			foreach (var user in _context.Users.ToList())
			{
				if (user == null)
					continue;

				cellData.Add(new object[] 
				{ 
					user.Id, 
					user.Group, 
					user.LastVisitDate.ToString("dd-MM-yyyy HH:mm"),
					user.RegistrationDate.ToString("dd-MM-yyyy HH:mm")
				});
			}

			return await ExportHelper.ExportToExcel(this, "Пользователи", headerRow, cellData);
		}
	}
}
