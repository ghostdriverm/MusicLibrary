using Microsoft.EntityFrameworkCore;
using MusicLibrary.Domain.Constants;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;
using MusicLibrary.Infrastructure.Persistence;

namespace MusicLibrary.Infrastructure.Repositories;

internal class SongsRepository(MusicLibraryDbContext dbContext) : ISongsRepository
{
    public async Task<Guid> Create(Song song)
    {
        song.SongId = Guid.NewGuid();
        await dbContext.Songs.AddAsync(song);
        await dbContext.SaveChangesAsync();
        return song.SongId;
    }

    public async Task Delete(Song song)
    {
        dbContext.Songs.Remove(song);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAll(IEnumerable<Song> songs)
    {
        dbContext.Songs.RemoveRange(songs);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Song>> GetAllAsync()
    {
        return await dbContext.Songs
            .Include(s => s.Album)
            .ThenInclude(a => a.Artist)
            .ToListAsync();
    }

    public async Task<IEnumerable<Song>> GetAllByAlbumAsync(Guid albumId)
    {
        return await dbContext.Songs
            .Include(s => s.Album)
            .Where(s => s.AlbumId == albumId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Song>> GetAllByArtistAsync(Guid artistId)
    {
        var albumIds = await dbContext.Albums
            .Where(a => a.ArtistId == artistId)
            .Select(a => a.AlbumId)
            .ToListAsync();

        return await dbContext.Songs
           .Where(s => albumIds.Contains(s.AlbumId))
           .ToListAsync();
    }

    public Task<(IEnumerable<Song>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
    {
        throw new NotImplementedException();
    }

    public async Task<Song> GetByIdAsync(Guid songId)
    {
        var song = await dbContext.Songs.FirstOrDefaultAsync(s => s.SongId == songId);
        if (song == null)
        {
            throw new Exception($"Song with ID {songId} not found.");
        }
        return song;
    }

    public async Task SaveChanges() => await dbContext.SaveChangesAsync(); 
}
