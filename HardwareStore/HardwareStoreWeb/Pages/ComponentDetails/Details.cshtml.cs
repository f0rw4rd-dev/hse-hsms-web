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
    public class DetailsModel : PageModel
    {
        private readonly HardwareStoreWeb.StoreContext _context;

        public DetailsModel(HardwareStoreWeb.StoreContext context)
        {
            _context = context;
        }

        public ComponentDetail ComponentDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ComponentDetails == null)
            {
                return NotFound();
            }

            var componentdetail = await _context.ComponentDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (componentdetail == null)
            {
                return NotFound();
            }
            else
            {
                ComponentDetail = componentdetail;
            }
            return Page();
        }
    }
}
