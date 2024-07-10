namespace MusicLibrary.Domain.Entities;

public class Album
{
    public Guid AlbumId { get; set; }
    public Guid ArtistId { get; set; }
    public string Title { get; set; } = default!;
    public List<Song> Songs { get; set; } = new();
    public string Description { get; set; } = default!;

    public Artist Artist { get; set; } = new();
    
}
