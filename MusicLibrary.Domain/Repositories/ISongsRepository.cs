using MusicLibrary.Domain.Constants;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Repositories;

public interface ISongsRepository
{
    Task<IEnumerable<Song>> GetAllAsync();
    Task<Song> GetByIdAsync(Guid songId);
    Task<IEnumerable<Song>> GetAllByAlbumAsync(Guid albumId);
    Task<IEnumerable<Song>> GetAllByArtistAsync(Guid artistId);
    Task<Guid> Create(Song song);
    Task SaveChanges();
    Task Delete(Song song);
    Task DeleteAll(IEnumerable<Song> songs);
    Task<(IEnumerable<Song>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
}
