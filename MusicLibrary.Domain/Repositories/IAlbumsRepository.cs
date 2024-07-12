using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Domain.Repositories;

public interface IAlbumsRepository
{
    Task<IEnumerable<Album>> GetAllAsync();
    Task<Album> GetByIdAsync(Guid albumId);
    Task<IEnumerable<Album>> GetAllByArtistAsync(Guid artistId);
    Task<Guid> Create(Album album);
    Task SaveChanges();
    Task Delete(Album album);
    Task DeleteAll(IEnumerable<Album> album);
}
