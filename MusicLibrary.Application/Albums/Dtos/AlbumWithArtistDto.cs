namespace MusicLibrary.Application.Albums.Dtos;

public class AlbumWithArtistDto
{
    public Guid AlbumId { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid ArtistId { get; set; }
    public string ArtistName { get; set; } = default!;
    
}
