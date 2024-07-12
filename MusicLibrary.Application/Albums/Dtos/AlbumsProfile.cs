using AutoMapper;
using MusicLibrary.Application.Albums.Commands.CreateAlbum;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Application.Albums.Dtos;

public class AlbumsProfile : Profile
{
    public AlbumsProfile()
    {
        CreateMap<CreateAlbumCommand, Album>()
            .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId));

        CreateMap<Album, AlbumDto>()
            .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
            .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs));
    }
}
