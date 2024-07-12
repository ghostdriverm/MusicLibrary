using AutoMapper;
using MusicLibrary.Application.Songs.Commands.CreateSongCommand;
using MusicLibrary.Application.Songs.Commands.UpdateSongCommand;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Application.Songs.Dtos;

public class SongsProfile : Profile
{
    public SongsProfile()
    {
        CreateMap<UpdateSongCommand, Song>();

        CreateMap<CreateSongCommand, Song>()
            .ForMember(dest => dest.SongId, opt => opt.MapFrom(src => src.SongId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
            .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId));

        CreateMap<Song, SongDto>()
            .ForMember(dest => dest.SongId, opt => opt.MapFrom(src => src.SongId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
            .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId))
            .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Album.ArtistId));
    }
}
