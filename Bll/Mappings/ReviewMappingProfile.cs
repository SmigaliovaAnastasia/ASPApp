using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Dtos.ReviewDtos;
using ASPApp.Domain.Entities;
using AutoMapper;

namespace ASPApp.Bll.Mappings
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.ApplicationUser.UserName))
                .ForMember(x => x.UserImageUrl, y => y.MapFrom(z => z.ApplicationUser.ImageUrl));
            CreateMap<ReviewUpdateDto, Review>();
        }
    }
}
