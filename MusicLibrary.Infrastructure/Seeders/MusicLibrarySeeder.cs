using Microsoft.EntityFrameworkCore;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Infrastructure.Persistence;
using System.Text.Json;

namespace MusicLibrary.Infrastructure.Seeders;

internal class MusicLibrarySeeder(MusicLibraryDbContext dbContext) : IMusicLibrarySeeder
{
    public async Task Seed()
    {
        // 1. Load JSON data from a file or string
        string jsonData = File.ReadAllText("data.json");

        if (jsonData != null)
        {
            // 2. Deserialize JSON into a list of dictionaries
            var musicData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonData);

            // 3. Process each artist's data
            if (musicData == null)
            {
                return;
            }
            foreach (var artistData in musicData)
            {

                // 3.1. Create the Artist
                var artist = new Artist
                {
                    Name = artistData["name"].ToString()
                };
                dbContext.Artists.Add(artist);

                // 3.2. Process each album for this artist
                var albumsJsonElement = artistData["albums"].ToString();
                var albums = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(albumsJsonElement);
                if (albums == null)
                {
                    return;
                }
                foreach (var albumData in albums)
                {
                    var album = new Album
                    {
                        Title = albumData["title"].ToString(),
                        Description = albumData["description"].ToString(),
                        Artist = artist
                    };
                    dbContext.Albums.Add(album);

                    // 3.3. Process each song for this album
                    var songsJsonElement = albumData["songs"].ToString();
                    var songs = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(songsJsonElement);
                    if (songs == null)
                    {
                        return;
                    }
                    foreach (var songData in songs)
                    {
                        var song = new Song
                        {
                            Title = songData["title"].ToString(),
                            Length = songData["length"].ToString(), // Helper for length parsing
                            Album = album,
                            Artist = artist
                        };
                        dbContext.Songs.Add(song);
                    }
                }
            }

            // 4. Save changes to the database
            await dbContext.SaveChangesAsync();
        }
    }
        

}
