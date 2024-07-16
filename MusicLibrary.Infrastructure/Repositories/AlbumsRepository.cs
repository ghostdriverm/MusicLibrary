using Microsoft.EntityFrameworkCore;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;
using MusicLibrary.Infrastructure.Persistence;

namespace MusicLibrary.Infrastructure.Repositories;

internal class AlbumsRepository(MusicLibraryDbContext dbContext) : IAlbumsRepository
{
    public async Task<Guid> Create(Album album)
    {
        album.AlbumId = Guid.NewGuid();
        await dbContext.Albums.AddAsync(album);
        await dbContext.SaveChangesAsync();
        return album.AlbumId;
    }

    public async Task Delete(Album album)
    {
        dbContext.Albums.Remove(album);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAll(IEnumerable<Album> albums)
    {
        dbContext.Albums.RemoveRange(albums);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Album>> GetAllAsync()
    {
        return await dbContext.Albums.ToListAsync();
    }

    public async Task<IEnumerable<Album>> GetAllByArtistAsync(Guid artistId)
    {
        return await dbContext.Albums.Where(a => a.ArtistId == artistId).ToListAsync();
    }

    public async Task<Album> GetByIdAsync(Guid albumId)
    {
        var album = await dbContext.Albums
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.AlbumId == albumId);

        if (album == null)
        {
            throw new Exception($"Album with ID {albumId} not found.");
        }

        return album;
    }

    public async Task<Album> GetAlbumOfTheDay()
    {
        var randomAlbum = await dbContext.Albums
            .OrderBy(x => Guid.NewGuid()) // order randomly
            .FirstOrDefaultAsync();

        return randomAlbum;
    }

    public async Task UpdateAsync(IEnumerable<Album> albums)
    {
        dbContext.Albums.UpdateRange(albums);
        await dbContext.SaveChangesAsync();
    }

    public Task SaveChanges() => dbContext.SaveChangesAsync();
}
