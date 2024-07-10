using Microsoft.EntityFrameworkCore;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Infrastructure.Persistence;

internal class MusicLibraryDbContext(DbContextOptions<MusicLibraryDbContext> options) : DbContext(options)
{
    internal DbSet<Artist> Artists { get; set; }
    internal DbSet<Album> Albums { get; set; }
    internal DbSet<Song> Songs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Artist>()
            .HasMany(a => a.Albums)
            .WithOne(a => a.Artist)
            .HasForeignKey(a => a.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Artist>()
            .HasMany(a => a.Songs)
            .WithOne(s => s.Artist)
            .HasForeignKey(s => s.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Album>()
            .HasMany(a => a.Songs)
            .WithOne(s => s.Album)
            .HasForeignKey(s => s.AlbumId);

        base.OnModelCreating(modelBuilder);
    }

}
