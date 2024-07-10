namespace MusicLibrary.Domain.Entities;

public class Song
{
    public int Id { get; set; }
    public int AlbumId { get; set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;

    public Album? Album { get; set; }
}
