using ASPApp.Common.Dtos.ApplicationUserDtos;
using ASPApp.Common.Dtos.CollectionGameDtos;
using ASPApp.Domain.Entities;
using ASPApp.Domain.Entities.Auth;
using AutoMapper;

namespace ASPApp.Bll.Mappings
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUserLoginDto, ApplicationUser>();
            CreateMap<ApplicationUserRegisterDto, ApplicationUser>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
        }
    }
}
