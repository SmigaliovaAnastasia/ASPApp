using ASPApp.Common.Dtos.CollectionGameDtos;
using ASPApp.Domain.Entities;
using AutoMapper;

namespace ASPApp.Bll.Mappings
{
    public class CollectionGameMappingProfile : Profile
    {
        public CollectionGameMappingProfile()
        {
            CreateMap<CollectionGame, CollectionGameDto>()
                .ForMember(x => x.GameName, y => y.MapFrom(z => z.Game.Name))
                .ForMember(x => x.GameImageUrl, y => y.MapFrom(z => z.Game.ImageUrl));
            CreateMap<CollectionGameCreateDto, CollectionGame>();
            CreateMap<CollectionGameUpdateDto, CollectionGame>();
        }
    }
}
