using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Dtos.ReviewDtos;
using ASPApp.Common.Models.Pagination;
using ASPApp.Domain.Entities;

namespace ASPApp.Bll.Interfaces
{
    public interface IReviewService
    {
        Task<PagedResult<ReviewDto>> GetPagedReviewsAsync(PagedRequest<Review> request);

        Task<ReviewDto> GetReviewAsync(Guid id);

        Task<ReviewDto> CreateReviewAsync(ReviewCreateDto reviewUpdateDto);

        Task UpdateReviewAsync(Guid id, ReviewUpdateDto reviewUpdateDto);

        Task DeleteReviewAsync(Guid id);
    }
}
