using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicPlaylistPage.Data;
using MusicPlaylistPage.Models;

namespace MusicPlaylistPage.Pages_Music
{
    public class DetailsModel : PageModel
    {
        private readonly MusicPlaylistPage.Data.MusicPlaylistPageContext _context;

        public DetailsModel(MusicPlaylistPage.Data.MusicPlaylistPageContext context)
        {
            _context = context;
        }

        public Music Music { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music.FirstOrDefaultAsync(m => m.Id == id);

            if (music is not null)
            {
                Music = music;

                return Page();
            }

            return NotFound();
        }
    }
}
