using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLibrary.Domain.Entities;

public class Song
{
    public Guid SongId { get; set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;

    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }

   
    public Guid? AlbumId { get; set; }
    public Album Album { get; set; }
    
}
