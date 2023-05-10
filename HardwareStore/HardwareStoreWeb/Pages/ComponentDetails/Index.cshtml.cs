using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

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

        public async Task OnGetAsync()
        {
            if (_context.ComponentDetails != null)
            {
                ComponentDetail = await _context.ComponentDetails
                .Include(c => c.Component)
                .Include(c => c.DetailType).ToListAsync();
            }
        }
    }
}
