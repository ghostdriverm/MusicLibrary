using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MusicLibrary.Domain.Constants;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;
using MusicLibrary.Infrastructure.Persistence;

namespace MusicLibrary.Infrastructure.Repositories;

internal class ArtistsRepository(MusicLibraryDbContext dbContext) : IArtistsRepository
{
    public async Task<Guid> Create(Artist artist)
    {
        artist.ArtistId = Guid.NewGuid();
        dbContext.Artists.Add(artist);
        await dbContext.SaveChangesAsync();
        return artist.ArtistId;
    }

    public async Task Delete(Artist artist)
    {
        dbContext.Remove(artist);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Artist>> GetAllAsync()
    {
        return await dbContext.Artists.ToListAsync();

    }
    //not used in the final project even though it should
    public Task<(IEnumerable<Artist>, Guid)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
    {
        //var searchPhraseLower = searchPhrase?.ToLower();

        //var baseQuery = dbContext
        //    .Artists
        //    .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
        //                                          || (foreach (song in r.Songs)
        //{
        //                                                song.ToLower().Contains(searchPhraseLower))
        //}
        throw new NotImplementedException();
    }

    public async Task<Artist?> GetByIdAsync(Guid artistId)
    {
        var artist = await dbContext.Artists
             .Include(a => a.Albums)
             .ThenInclude(album => album.Songs)
             .FirstOrDefaultAsync(x => x.ArtistId == artistId);

        return artist;
    }

    public async Task<Artist?> GetByNameAsync(string name)
    {
        return await dbContext.Artists.Include(a => a.Albums).FirstOrDefaultAsync(a => a.Name == name);
    }

    public Task SaveChanges() => dbContext.SaveChangesAsync();

    public async Task UpdateAsync(Artist artist)
    {

        dbContext.Artists.Update(artist);
        await dbContext.SaveChangesAsync();
    }

    Task<(IEnumerable<Artist>, int)> IArtistsRepository.GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
    {
        throw new NotImplementedException();
    }
}
