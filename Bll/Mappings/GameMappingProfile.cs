using AutoMapper;
using System.Security.Policy;
using ASPApp.Common.Dtos;
using ASPApp.Domain.Entities;

namespace ASPApp.Bll.Mappings
{
    public class GameMappingProfile : Profile
    {
        public GameMappingProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(x => x.ComplexityLevelDto, y => y.MapFrom(z => z.ComplexityLevel))
                .ForMember(x => x.GameSeriesDto, y => y.MapFrom(z => z.GameSeries))
                .ForMember(x => x.GenreDtos, y => y.MapFrom(z => z.Genres));
            CreateMap<GameUpdateDto, Game>();
            CreateMap<Game, GameListDto>()
                .ForMember(x => x.ComplexityLevelName, y => y.MapFrom(z => z.ComplexityLevel.Name))
                .ForMember(x => x.Genres, y => y.MapFrom(z => z.Genres.Select(g => g.Name)));

            CreateMap<GameSeries, GameSeriesDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<ComplexityLevel, ComplexityLevelDto>();
        }
    }
}
