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
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
        }
    }
}
