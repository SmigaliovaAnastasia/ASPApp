using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Dtos.ReviewDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination;
using ASPApp.Dal.Repository.Interfaces;
using ASPApp.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ASPApp.Bll.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;
        private readonly IMapper _mapper;

        public ReviewService(IRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewCreateDto reviewCreateDto)
        {
            var review = _mapper.Map<Review>(reviewCreateDto);
            var existanceCheck = await _repository.GetWithFiltersAsync(e =>
                e.GameId == review.GameId &&
                e.ApplicationUserId == review.ApplicationUserId);
            if (existanceCheck != null)
            {
                throw new EntryAlreadyExistsException("The review you are trying to add already exists");
            }
            await _repository.AddAsync(review);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task DeleteReviewAsync(Guid id)
        {
            try
            {
                await _repository.RemoveAsync(id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The review you are trying to delete was already deleted");
            }
        }

        public async Task<PagedResult<ReviewDto>> GetPagedReviewsAsync(PagedRequest<Review> request)
        {
            return await _repository.GetPagedResultAsync<ReviewDto>(request, _mapper, e => e.ApplicationUser);
        }

        public async Task<ReviewDto> GetReviewAsync(Guid id)
        {
            var review = await _repository.GetByIdWithIncludeAsync(id, e => e.ApplicationUser);
            if (review == null)
            {
                throw new EntryNotFoundException("The game you are requesting doesn't exist");
            }
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task UpdateReviewAsync(Guid id, ReviewUpdateDto reviewUpdateDto)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null)
            {
                throw new EntryNotFoundException("The review you are trying to update doesn't exist");
            }
            _mapper.Map(reviewUpdateDto, review);
            try
            {
                await _repository.UpdateAsync(review.Id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The review you are trying to update was already updated.");
            }
        }
    }
}
