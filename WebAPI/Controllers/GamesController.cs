using Microsoft.AspNetCore.Mvc;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Dtos.GameDtos;
using Microsoft.AspNetCore.Authorization;
using ASPApp.Domain.Entities.Auth;
using ASPApp.Bll.Interfaces;
using ASPApp.Common.Models.Pagination.PagedRequests;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get()
        {
            return Ok(await _gameService.GetAllGamesAsync());
        }

        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _gameService.GetGameAsync(id));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [ApiExceptionFilter]
        public async Task<IActionResult> Post([FromBody] GameUpdateDto gameDto)
        {
            var game = await _gameService.CreateGameAsync(gameDto);
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }

        [HttpPost("paginated")]
        [ApiExceptionFilter]
        public async Task<IActionResult> GetPaged([FromBody] GamePagedRequest request)
        {
            return Ok(await _gameService.GetPagedGamesAsync(request));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Put(Guid id, [FromBody] GameUpdateDto gameDto)
        {
            await _gameService.UpdateGameAsync(id, gameDto);
            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }

    }
}
