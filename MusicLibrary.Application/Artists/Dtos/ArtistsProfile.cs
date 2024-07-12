using AutoMapper;
using MusicLibrary.Application.Artists.Commands.CreateArtist;
using MusicLibrary.Application.Artists.Commands.UpdateArtist;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Application.Artists.Dtos;

public class ArtistsProfile : Profile
{
    public ArtistsProfile()
    {
        CreateMap<UpdateArtistCommand, Artist>();

        CreateMap<CreateArtistCommand, Artist>()

                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<Artist, ArtistDto>()
            .ForMember(dest => dest.ArtistId, opt =>
                opt.MapFrom(src => src.ArtistId))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Albums,
                opt => opt.MapFrom(src => src.Albums));

    }
}
