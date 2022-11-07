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
                .ForMember(x => x.GameDto, y => y.MapFrom(z => z.Game));
            CreateMap<CollectionGame, CollectionGameDto>();
        }
    }
}
