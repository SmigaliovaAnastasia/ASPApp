using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Domain.Entities;
using AutoMapper;

namespace ASPApp.Bll.Mappings
{
    public class CollectionMappingProfile : Profile
    {
        public CollectionMappingProfile()
        {
            CreateMap<Collection, CollectionDto>()
                .ForMember(x => x.GamesNumber, y => y.MapFrom(z => z.CollectionGames.Count()))
                .ForMember(x => x.FavouriteGamesNumber, y => y.MapFrom(z => z.CollectionGames.Select(c => c.IsFavourite == true).Count()));
            CreateMap<CollectionCreateDto, Collection>();
            CreateMap<CollectionUpdateDto, Collection>();
        }
    }
}
