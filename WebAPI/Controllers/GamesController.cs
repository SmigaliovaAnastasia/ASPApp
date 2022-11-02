using ASPApp.Bll.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ASPApp.Common.Dtos;
using System.Net;
using ASPApp.Common.Exceptions;
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

        [HttpPost]
        [ApiExceptionFilter]
        public async Task<IActionResult> Post([FromBody] GameUpdateDto gameDto)
        {
            var game = await _gameService.CreateGameAsync(gameDto);
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Put(Guid id, [FromBody] GameUpdateDto gameDto)
        {
            await _gameService.UpdateGameAsync(id, gameDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }

    }
}
