using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicPlaylistPage.Data;
using MusicPlaylistPage.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicPlaylistPage.Pages_Music
{
    public class IndexModel : PageModel
    {
        private readonly MusicPlaylistPage.Data.MusicPlaylistPageContext _context;

        public IndexModel(MusicPlaylistPage.Data.MusicPlaylistPageContext context)
        {
            _context = context;
        }

        public IList<Music> Music { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MusicGenre { get; set; }

        public async Task OnGetAsync()
        {
            // <snippet_search_linqQuery>
            IQueryable<string> genreQuery = from m in _context.Music
                                            orderby m.Genre
                                            select m.Genre;
            // </snippet_search_linqQuery>

            var musics = from m in _context.Music
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                musics = musics.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MusicGenre))
            {
                musics = musics.Where(x => x.Genre == MusicGenre);
            }

            // <snippet_search_selectList>
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            // </snippet_search_selectList>
            Music = await musics.ToListAsync();
        }
    }
}
