using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlaylistPage.Models;

namespace MusicPlaylistPage.Data
{
    public class MusicPlaylistPageContext : DbContext
    {
        public MusicPlaylistPageContext (DbContextOptions<MusicPlaylistPageContext> options)
            : base(options)
        {
        }

        public DbSet<MusicPlaylistPage.Models.Music> Music { get; set; } = default!;
    }
}
