using Microsoft.EntityFrameworkCore;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Infrastructure.Persistence;

internal class MusicLibraryDbContext : DbContext
{
    public MusicLibraryDbContext(DbContextOptions<MusicLibraryDbContext> options) : base(options)
    {
        
    }
    internal DbSet<Artist> Artists { get; set; }
    internal DbSet<Album> Albums { get; set; }
    internal DbSet<Song> Songs { get; set; }

    
}
