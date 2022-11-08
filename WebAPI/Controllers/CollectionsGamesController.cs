using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Common.Dtos.CollectionGameDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination.PagedRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsGamesController : ControllerBase
    {
        private readonly ICollectionGameService _collectionGameService;
        public CollectionsGamesController(ICollectionGameService collectionGameService)
        {
            _collectionGameService = collectionGameService;
        }

        [Authorize]
        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _collectionGameService.GetCollectionGameAsync(id));
        }

        [Authorize]
        [HttpPost]
        [ApiExceptionFilter]
        public async Task<IActionResult> Post([FromBody] CollectionGameCreateDto collectionGameCreateDto)
        {
            var collectionGame = await _collectionGameService.CreateCollectionGameAsync(collectionGameCreateDto);
            return CreatedAtAction(nameof(Get), new { id = collectionGame.Id }, collectionGame);
        }

        [HttpPost("paginated")]
        [ApiExceptionFilter]
        public async Task<IActionResult> GetPaged([FromBody] CollectionGamePagedRequest request)
        {
            return Ok(await _collectionGameService.GetPagedCollectionsGamesAsync(request));
        }

        [Authorize]
        [HttpPut("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Put(Guid id, [FromBody] CollectionGameUpdateDto collectionGameUpdateDto)
        {
            await _collectionGameService.UpdateCollectionGameAsync(id, collectionGameUpdateDto);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _collectionGameService.DeleteCollectionGameAsync(id);
            return NoContent();
        }
    }
}
