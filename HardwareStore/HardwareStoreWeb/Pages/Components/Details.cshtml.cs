using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HardwareStoreWeb;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Pages.Components
{
    public class DetailsModel : PageModel
    {
        private readonly HardwareStoreWeb.StoreContext _context;

        public DetailsModel(HardwareStoreWeb.StoreContext context)
        {
            _context = context;
        }

        public Component Component { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Components == null)
            {
                return NotFound();
            }

            var component = await _context.Components.FirstOrDefaultAsync(m => m.Id == id);
            if (component == null)
            {
                return NotFound();
            }
            else
            {
                Component = component;
            }
            return Page();
        }
    }
}
