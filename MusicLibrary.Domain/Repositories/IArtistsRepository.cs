using MusicLibrary.Domain.Constants;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Repositories;

public interface IArtistsRepository
{
    Task<IEnumerable<Artist>> GetAllAsync();
    Task<Artist?> GetByIdAsync(Guid artistId);
    Task<Artist?> GetByNameAsync(string name);
    Task<Guid> Create(Artist artist);
    Task UpdateAsync(Artist artist);
    Task SaveChanges();
    Task Delete(Artist artist);
    Task<(IEnumerable<Artist>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
}
