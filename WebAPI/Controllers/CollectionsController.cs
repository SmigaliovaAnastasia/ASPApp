using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Common.Dtos.ReviewDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination;
using ASPApp.Common.Models.Pagination.Filters;
using ASPApp.Common.Models.Pagination.PagedRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionService _collectionService;
        public CollectionsController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [Authorize]
        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            var collection = await _collectionService.GetCollectionAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (collection.ApplicationUserId.ToString() == userId)
                return Ok(collection);
            else
                return BadRequest("Users can not read collections of other users");
        }

        [Authorize]
        [HttpPost]
        [ApiExceptionFilter]
        public async Task<IActionResult> Post([FromBody] CollectionCreateDto collectionCreateDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == collectionCreateDto.ApplicationUserId.ToString())
            {
                var collection = await _collectionService.CreateCollectionAsync(collectionCreateDto);
                return CreatedAtAction(nameof(Get), new { id = collection.Id }, collection);
            }
            else
            {
                return BadRequest("Users can not create collections for other users");
            }
        }

        [HttpPost("paginated")]
        [ApiExceptionFilter]
        public async Task<IActionResult> GetPaged([FromBody] CollectionPagedRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.SetApplicationUserFilter(userId);
            return Ok(await _collectionService.GetPagedCollectionsAsync(request));
        }

        [Authorize]
        [HttpPut("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Put(Guid id, [FromBody] CollectionUpdateDto collectionUpdateDto)
        {
            if (await CheckUserAccess(id))
            {
                await _collectionService.UpdateCollectionAsync(id, collectionUpdateDto);
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
                await _collectionService.DeleteCollectionAsync(id);
                return Ok("Success");
            }
            return BadRequest("Access denied");
        }

        private async Task<bool> CheckUserAccess(Guid collectionId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var collection = await _collectionService.GetCollectionAsync(collectionId);
            if (collection.ApplicationUserId.ToString().ToLower() == userId)
            {
                return true;
            }
            return false;
        }
    }
}

