using HardwareStoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HardwareStoreWeb.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
		private readonly HardwareStoreWeb.StoreContext _context;

        public IndexModel(HardwareStoreWeb.StoreContext context)
        {
			_context = context;
		}

		[BindProperty]
		public Group Group { get; set; }

        public void OnGet()
        {
            ViewData["TotalComponents"] = _context.Components.Count();
            ViewData["TotalSupplies"] = _context.Supplies.Count();
            ViewData["TotalOrders"] = _context.Orders.Count();

			var userId = int.Parse(HttpContext.User.Identity!.Name!);
			var user = _context.Users.Find(userId);
			if (user != null)
			{
				Group = user.Group;
			}

			if (_context.Components.Any()) 
            {
				ViewData["PercentProcessedOrders"] = (int)Math.Floor(_context.Orders.Where(x => x.Status != Models.OrderStatus.Created && x.Status != Models.OrderStatus.Processing).Count() / (double)_context.Orders.Count() * 100);
			}
            else
            {
                ViewData["PercentProcessedOrders"] = 100;

			}
		}
    }
}