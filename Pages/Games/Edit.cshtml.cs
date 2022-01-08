using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicatie_Web.Data;
using Aplicatie_Web.Models;

namespace Aplicatie_Web.Pages.Games
{
    public class EditModel : GameCategoriesPageModel
    {
        private readonly Aplicatie_Web.Data.Aplicatie_WebContext _context;

        public EditModel(Aplicatie_Web.Data.Aplicatie_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.Include(b => b.Studio).Include(b => b.GameCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
          

            if (Game == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Game);

            ViewData["StudioID"] = new SelectList(_context.Set<Studio>(), "ID", "Studioname");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gameToUpdate = await _context.Game
            .Include(i => i.Studio)
            .Include(i => i.GameCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (gameToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Game>(
            gameToUpdate,
            "Game",
            i => i.Title, i => i.Platform,                          // AICI E POSIBIL SA AM O EROARE
            i => i.Price, i => i.Quantity, i => i.LaunchDate, i => i.Studio))
            {
                UpdateGameCategories(_context, selectedCategories, gameToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateGameCategories(_context, selectedCategories, gameToUpdate);
            PopulateAssignedCategoryData(_context, gameToUpdate);
            return Page();
        }
    }
/*
    private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.ID == id);
        }
    }
*/
}
