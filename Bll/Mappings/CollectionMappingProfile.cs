using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Domain.Entities;
using AutoMapper;

namespace ASPApp.Bll.Mappings
{
    public class CollectionMappingProfile : Profile
    {
        public CollectionMappingProfile()
        {
            CreateMap<Collection, CollectionDto>();
            CreateMap<CollectionUpdateDto, Collection>();
        }
    }
}
