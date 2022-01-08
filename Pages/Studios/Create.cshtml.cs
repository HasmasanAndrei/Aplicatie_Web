using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aplicatie_Web.Data;
using Aplicatie_Web.Models;

namespace Aplicatie_Web.Pages.Studios
{
    public class CreateModel : PageModel
    {
        private readonly Aplicatie_Web.Data.Aplicatie_WebContext _context;

        public CreateModel(Aplicatie_Web.Data.Aplicatie_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            

            return Page();
        }

        [BindProperty]
        public Studio Studio { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Studio.Add(Studio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
