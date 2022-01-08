using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aplicatie_Web.Data;
using Aplicatie_Web.Models;

namespace Aplicatie_Web.Pages.Studios
{
    public class DetailsModel : PageModel
    {
        private readonly Aplicatie_Web.Data.Aplicatie_WebContext _context;

        public DetailsModel(Aplicatie_Web.Data.Aplicatie_WebContext context)
        {
            _context = context;
        }

        public Studio Studio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Studio = await _context.Studio.FirstOrDefaultAsync(m => m.ID == id);

            if (Studio == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
