using AutoMapper;
using System.Security.Policy;
using ASPApp.Domain.Entities;
using ASPApp.Common.Dtos.GameDtos;

namespace ASPApp.Bll.Mappings
{
    public class GameMappingProfile : Profile
    {
        public GameMappingProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(x => x.ComplexityLevelDto, y => y.MapFrom(z => z.ComplexityLevel))
                .ForMember(x => x.GameSeriesDto, y => y.MapFrom(z => z.GameSeries))
                .ForMember(x => x.GenreDtos, y => y.MapFrom(z => z.Genres))
                .ForMember(x => x.Rating, y => y.MapFrom(z => z.Reviews.Count > 0 ? Math.Round(z.Reviews.Average(r => r.Rating),2) : 0))
                .ForMember(x => x.ReviewIds, y => y.MapFrom(z => z.Reviews.Select(r => r.Id)));
            CreateMap<GameUpdateDto, Game>();
            CreateMap<Game, GameListDto>()
                .ForMember(x => x.ComplexityLevelName, y => y.MapFrom(z => z.ComplexityLevel.Name))
                .ForMember(x => x.Rating, y => y.MapFrom(z => z.Reviews.Count > 0 ? Math.Round(z.Reviews.Average(r => r.Rating), 2) : 0))
                .ForMember(x => x.Genres, y => y.MapFrom(z => z.Genres.Select(g => g.Name)));

            CreateMap<GameSeries, GameSeriesDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<ComplexityLevel, ComplexityLevelDto>();
        }
    }
}
