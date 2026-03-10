using Microsoft.EntityFrameworkCore;
using MusicPlaylistPage.Data;

namespace MusicPlaylistPage.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MusicPlaylistPageContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MusicPlaylistPageContext>>()))
        {
            if (context == null || context.Music == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Music.Any())
            {
                return;   // DB has been seeded
            }

            context.Music.AddRange(
                new Music
                {
                    Title = "No Idea",
                    ReleaseDate = DateTime.Parse("2020-2-12"),
                    Genre = "R&B",
                    Price = 1.99M,
                    Artist = "Don Toliver"
                },

                new Music
                {
                    Title = "Ca$ino",
                    ReleaseDate = DateTime.Parse("2026-2-17"),
                    Genre = "Hip Hop/Rap",
                    Price = 2.99M,
                    Artist = "Baby Keem"
                },

                new Music
                {
                    Title = "No Bystanders",
                    ReleaseDate = DateTime.Parse("2018-8-03"),
                    Genre = "Hip Hop/Rap",
                    Price = 4.99M,
                    Artist = "Travis Scott"
                },

                new Music
                {
                    Title = "Reflections Laughing",
                    ReleaseDate = DateTime.Parse("2025-1-31"),
                    Genre = "Pop/R&B",
                    Price = 1.95M,
                    Artist = "The Weeknd"
                }
            );
            context.SaveChanges();
        }
    }
}