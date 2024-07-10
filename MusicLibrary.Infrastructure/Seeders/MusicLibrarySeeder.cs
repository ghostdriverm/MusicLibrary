using MusicLibrary.Domain.Entities;
using MusicLibrary.Infrastructure.Persistence;

namespace MusicLibrary.Infrastructure.Seeders;

internal class MusicLibrarySeeder(MusicLibraryDbContext dbContext) : IMusicLibrarySeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Artists.Any())
            {
                var artists = GetArtists();
                dbContext.Artists.AddRange(artists);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Artist> GetArtists()
    {
        List<Artist> artists = [
            new (){
                Name = "Radiohead",
                Albums = {
                   new (){
                       Title = "The King of Limbs",
                       Songs = {
                            new Song()
                            {
                            Title = "Bloom",
                            Length = "5:15"
                            },
                            new Song()
                            {
                            Title = "Morning Mr Magpie",
                            Length = "4:41"
                            },
                            new Song()
                            {
                            Title = "Little by Little",
                            Length = "4:27"
                            },
                            new Song()
                            {
                            Title = "Feral",
                            Length = "3:13"
                            },
                            new Song()
                            {
                            Title = "Lotus Flower",
                            Length = "5:01"
                            },
                            new Song()
                            {
                            Title = "Codex",
                            Length = "4:47"
                            },
                            new Song()
                            {
                            Title = "Give Up the Ghost",
                            Length = "4:50"
                            },
                            new Song()
                            {
                            Title = "Separator",
                            Length = "5:20"
                            }
                       },
                       Description = "\n\tThe King of Limbs is the eighth studio album by English rock band Radiohead, produced by Nigel Godrich. It was self-released on 18 February 2011 as a download in MP3 and WAV formats, followed by physical CD and 12\" vinyl releases on 28 March, a wider digital release via AWAL, and a special \"newspaper\" edition on 9 May 2011. The physical editions were released through the band's Ticker Tape imprint on XL in the United Kingdom, TBD in the United States, and Hostess Entertainment in Japan.\n      "

                   },
                   new () {
                        Title = "OK Computer",
                        Songs = {
                            new Song()
                            {
                            Title = "Airbag",
                            Length = "4:44"
                            },
                            new Song()
                            {
                            Title = "Paranoid Android",
                            Length = "6:23"
                            },
                            new Song()
                            {
                            Title = "Subterranean Homesick Alien",
                            Length = "4:27"
                            },
                            new Song()
                            {
                            Title = "Exit Music (For a Film)",
                            Length = "4:24"
                            },
                            new Song()
                            {
                            Title = "Let Down",
                            Length = "4:59"
                            },
                            new Song()
                            {
                            Title = "Karma Police",
                            Length = "4:21"
                            },
                            new Song()
                            {
                            Title = "Fitter Happier",
                            Length = "1:57"
                            },
                            new Song()
                            {
                            Title = "Electioneering",
                            Length = "3:50"
                            },
                            new Song()
                            {
                            Title = "Climbing Up the Walls",
                            Length = "4:45"
                            },
                            new Song()
                            {
                            Title = "No Surprises",
                            Length = "3:48"
                            },
                            new Song()
                            {
                            Title = "Lucky",
                            Length = "4:19"
                            },
                            new Song()
                            {
                            Title = "The Tourist",
                            Length = "5:24"
                            }
                        },
                        Description = "\n\tOK Computer is the third studio album by the English alternative rock band Radiohead, released on 16 June 1997 on Parlophone in the United Kingdom and 1 July 1997 by Capitol Records in the United States. It marks a deliberate attempt by the band to move away from the introspective guitar-oriented sound of their previous album The Bends. Its layered sound and wide range of influences set it apart from many of the Britpop and alternative rock bands popular at the time and laid the groundwork for Radiohead's later, more experimental work.\n"
                   },
                },
            },
            new () {
                Name = "Portishead",
                Albums = {
                   new (){
                        Title = "Dummy",
                        Songs = {
                            new Song()
                            {
                            Title = "Mysterons",
                            Length = "5:02"
                            },
                            new Song()
                            {
                            Title = "Sour Times",
                            Length = "4:11"
                            },
                            new Song()
                            {
                            Title = "Strangers",
                            Length = "3:55"
                            },
                            new Song()
                            {
                            Title = "It Could Be Sweet",
                            Length = "4:16"
                            },
                            new Song()
                            {
                            Title = "Wandering Star",
                            Length = "4:51"
                            },
                            new Song()
                            {
                            Title = "It's a Fire",
                            Length = "3:49"
                            },
                            new Song()
                            {
                            Title = "Numb",
                            Length = "3:54"
                            },
                            new Song()
                            {
                            Title = "Roads",
                            Length = "5:02"
                            },
                            new Song()
                            {
                            Title = "Pedestal",
                            Length = "3:39"
                            },
                            new Song()
                            {
                            Title = "Biscuit",
                            Length = "5:01"
                            },
                            new Song()
                            {
                            Title = "Glory Box",
                            Length = "5:06"
                            }
                        },
                        Description = "\n\tDummy is the debut album of the Bristol-based group Portishead. Released in August 22, 1994 on Go! Discs, the album earned critical acclaim, winning the 1995 Mercury Music Prize. It is often credited with popularizing the trip-hop genre and is frequently cited in lists of the best albums of the 1990s. Although it achieved modest chart success overseas, it peaked at #2 on the UK Album Chart and saw two of its three singles reach #13. The album was certified gold in 1997 and has sold two million copies in Europe. As of September 2011, the album was certified double-platinum in the United Kingdom and has sold as of September 2011 825,000 copies.\n      "
                    },
                   new (){
                        Title = "Third",
                        Songs = {
                            new Song()
                            {
                            Title = "Silence",
                            Length = "4:58"
                            },
                            new Song()
                            {
                            Title = "Hunter",
                            Length = "3:57"
                            },
                            new Song()
                            {
                            Title = "Nylon Smile",
                            Length = "3:16"
                            },
                            new Song()
                            {
                            Title = "The Rip",
                            Length = "4:29"
                            },
                            new Song()
                            {
                            Title = "Plastic",
                            Length = "3:27"
                            },
                            new Song()
                            {
                            Title = "We Carry On",
                            Length = "6:27"
                            },
                            new Song()
                            {
                            Title = "Deep Water",
                            Length = "1:31"
                            },
                            new Song()
                            {
                            Title = "Machine Gun",
                            Length = "4:43"
                            },
                            new Song()
                            {
                            Title = "Small",
                            Length = "6:45"
                            },
                            new Song()
                            {
                            Title = "Magic Doors",
                            Length = "3:32"
                            },
                            new Song()
                            {
                            Title = "Threads",
                            Length = "5:45"
                            }
                        },
                        Description = "\n\tThird is the third studio album by English musical group Portishead, released on 27 April 2008, on Island Records in the United Kingdom, two days after on Mercury Records in the United States, and on 30 April 2008 on Universal Music Japan in Japan. It is their first release in 10 years, and their first studio album in eleven years. Third entered the UK Album Chart at #2, and became the band's first-ever American Top 10 album on the Billboard 200, reaching #7 in its entry week.\n      "
                   },
                },
            },
            new (){
                Name = "Rammstein",
                Albums = {
                   new (){
                        Title = "Herzeleid",
                        Songs = {
                            new Song()
                            {
                            Title = "Wollt ihr das Bett in Flammen sehen?",
                            Length = "5:17"
                            },
                            new Song()
                            {
                            Title = "Der Meister",
                            Length = "4:08"
                            },
                            new Song()
                            {
                            Title = "Weißes Fleisch",
                            Length = "3:35"
                            },
                            new Song()
                            {
                            Title = "Asche zu Asche",
                            Length = "3:51"
                            },
                            new Song()
                            {
                            Title = "Seemann",
                            Length = "4:48"
                            },
                            new Song()
                            {
                            Title = "Du riechst so gut",
                            Length = "4:49"
                            },
                            new Song()
                            {
                            Title = "Das alte Leid",
                            Length = "5:44"
                            },
                            new Song()
                            {
                            Title = "Heirate mich",
                            Length = "4:44"
                            },
                            new Song()
                            {
                            Title = "Herzeleid",
                            Length = "3:41"
                            },
                            new Song()
                            {
                            Title = "Laichzeit",
                            Length = "4:20"
                            },
                            new Song()
                            {
                            Title = "Rammstein",
                            Length = "4:25"
                            }
                        },
                        Description = "\n\tHerzeleid is the debut album by German Neue Deutsche Härte band Rammstein. It was released on 29 September 1995 through Motor Music. The album's original cover depicted the band members' upper bodies without clothing. This caused critics to accuse the band of trying to sell themselves as \"poster boys for the master race\". The cover was replaced with a less controversial design for the album's international release. Despite the controversy, Herzeleid has been well received by critics and has since been certified platinum in Germany.\n "
                   },
                   new (){
                        Title = "Mutter",
                        Songs = {
                            new Song()
                            {
                                Title = "Mein Herz brennt",
                                Length = "4:39"
                            },
                            new Song()
                            {
                                Title = "Links 2-3-4",
                                Length = "3:36"
                            },
                            new Song()
                            {
                                Title = "Sonne",
                                Length = "4:32"
                            },
                            new Song()
                            {
                                Title = "Ich will",
                                Length = "3:37"
                            },
                            new Song()
                            {
                                Title = "Feuer frei!",
                                Length = "3:08"
                            },
                            new Song()
                            {
                                Title = "Mutter",
                                Length = "4:28"
                            },
                            new Song()
                            {
                                Title = "Spieluhr",
                                Length = "4:46"
                            },
                            new Song()
                            {
                                Title = "Zwitter",
                                Length = "4:17"
                            },
                            new Song()
                            {
                                Title = "Rein raus",
                                Length = "3:09"
                            },
                            new Song()
                            {
                                Title = "Adios",
                                Length = "3:49"
                            },
                            new Song()
                            {
                                Title = "Nebel",
                                Length = "4:54"
                            }
                        },
                        Description = "\n\tMutter is the third album by German Neue Deutsche Härte band Rammstein. It was released on 2 April 2001 through Motor and Universal Music. The album's title means \"mother\" in German and is a reference to the band's song of the same name. Mutter has been well received by critics and was a commercial success, reaching number one in Germany, Austria, and Switzerland. It has since been certified platinum in several countries.\n "
                   },
                },
            },
            new (){
                Name = "Taylor Swift",
                Albums = {
                   new () {
                        Title = "Fearless",
                        Songs = {
                            new Song()
                            {
                                Title = "Fearless",
                                Length = "4:01"
                            },
                            new Song()
                            {
                                Title = "Fifteen",
                                Length = "4:54"
                            },
                            new Song()
                            {
                                Title = "Love Story",
                                Length = "3:55"
                            },
                            new Song()
                            {
                                Title = "Hey Stephen",
                                Length = "4:14"
                            },
                            new Song()
                            {
                                Title = "White Horse",
                                Length = "3:55"
                            },
                            new Song()
                            {
                                Title = "You Belong with Me",
                                Length = "3:52"
                            },
                            new Song()
                            {
                                Title = "Breathe",
                                Length = "4:23"
                            },
                            new Song()
                            {
                                Title = "Tell Me Why",
                                Length = "3:20"
                            },
                            new Song()
                            {
                                Title = "You're Not Sorry",
                                Length = "4:22"
                            },
                            new Song()
                            {
                                Title = "The Way I Loved You",
                                Length = "4:04"
                            },
                            new Song()
                            {
                                Title = "Forever & Always",
                                Length = "3:46"
                            },
                            new Song()
                            {
                                Title = "The Best Day",
                                Length = "4:05"
                            },
                            new Song()
                            {
                                Title = "Change",
                                Length = "4:40"
                            }
                        },
                        Description = "\n\tFearless is the second studio album by American singer-songwriter Taylor Swift. It was released on November 11, 2008, by Big Machine Records. The album was a commercial success, topping the Billboard 200 for 11 non-consecutive weeks. It was also the best-selling album of 2009 in the United States. Fearless has been certified Diamond by the Recording Industry Association of America (RIAA) and has sold over 10 million copies worldwide. It won four Grammy Awards, including Album of the Year, making Swift the youngest recipient of the award at the time.\n "
                    },
                   new (){
                        Title = "1989",
                        Songs = {
                            new Song()
                            {
                                Title = "Welcome to New York",
                                Length = "3:32"
                            },
                            new Song()
                            {
                                Title = "Blank Space",
                                Length = "3:51"
                            },
                            new Song()
                            {
                                Title = "Style",
                                Length = "3:51"
                            },
                            new Song()
                            {
                                Title = "Out of the Woods",
                                Length = "3:55"
                            },
                            new Song()
                            {
                                Title = "All You Had to Do Was Stay",
                                Length = "3:13"
                            },
                            new Song()
                            {
                                Title = "Shake It Off",
                                Length = "3:39"
                            },
                            new Song()
                            {
                                Title = "I Wish You Would",
                                Length = "3:27"
                            },
                            new Song()
                            {
                                Title = "Bad Blood",
                                Length = "3:31"
                            },
                            new Song()
                            {
                                Title = "Wildest Dreams",
                                Length = "3:40"
                            },
                            new Song()
                            {
                                Title = "How You Get the Girl",
                                Length = "4:07"
                            },
                            new Song()
                            {
                                Title = "This Love",
                                Length = "4:10"
                            },
                            new Song()
                            {
                                Title = "I Know Places",
                                Length = "3:15"
                            },
                            new Song()
                            {
                                Title = "Clean",
                                Length = "4:31"
                            }
                        },
                        Description = "\n\t1989 is the fifth studio album by American singer-songwriter Taylor Swift. It was released on October 27, 2014, through Big Machine Records. The album marked a departure from the country music that had been Swift's trademark sound, and is described as her evolution into pop music. 1989 received generally positive reviews from music critics and was a commercial success, debuting at number one on the Billboard 200 and selling over 1.28 million copies in its first week. It has since been certified 9× Platinum by the RIAA and has sold over 10 million copies worldwide.\n "
                   },
                },
            },
        ];

        return artists;
    }
}
