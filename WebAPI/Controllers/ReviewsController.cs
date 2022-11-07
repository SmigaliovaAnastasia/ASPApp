using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Dtos.ReviewDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination.PagedRequests;
using ASPApp.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _reviewService.GetReviewAsync(id));
        }

        [Authorize]
        [HttpPost]
        [ApiExceptionFilter]
        public async Task<IActionResult> Post([FromBody] ReviewUpdateDto reviewUpdateDto)
        {
            var review = await _reviewService.CreateReviewAsync(reviewUpdateDto);
            return CreatedAtAction(nameof(Get), new { id = review.Id }, review);
        }

        [HttpPost("paginated")]
        [ApiExceptionFilter]
        public async Task<IActionResult> GetPaged([FromBody] ReviewPagedRequest request)
        {
            return Ok(await _reviewService.GetPagedReviewsAsync(request));
        }

        [Authorize]
        [HttpPut("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Put(Guid id, [FromBody] ReviewUpdateDto reviewUpdateDto)
        {
            if (await CheckUserAccess(id))
            {
                await _reviewService.UpdateReviewAsync(id, reviewUpdateDto);
                return Ok();
            }
            return BadRequest("Access denied");
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await CheckUserAccess(id))
            {
                await _reviewService.DeleteReviewAsync(id);
                return NoContent();
            }
            return BadRequest("Access denied");
        }

        private async Task<bool> CheckUserAccess(Guid reviewId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var review = await _reviewService.GetReviewAsync(reviewId);
            if(review.ApplicationUserId.ToString() == userId)
            {
                return true;
            }
            return false;
        }
    }
}
