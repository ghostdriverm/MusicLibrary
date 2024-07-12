namespace MusicLibrary.Domain.Entities;

public class Album
{
    public Guid AlbumId { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;

    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; } = null!;

    public ICollection<Song> Songs { get; set; } = new List<Song>();

}
