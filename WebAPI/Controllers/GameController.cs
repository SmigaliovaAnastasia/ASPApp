using ASPApp.Bll.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ASPApp.Common.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/<GameController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _gameService.GetAllGamesAsync());
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _gameService.GetGameAsync(id));
        }

        // POST api/<GameController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameUpdateDto gameDto)
        {
            var game = await _gameService.CreateGameAsync(gameDto);
            if(game == null)
            { 
                return BadRequest("Unable to create game.");
            }
            return CreatedAtAction(nameof(Get), new { id = game.GameId }, game);
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GameUpdateDto gameDto)
        {
            var game = await _gameService.UpdateGameAsync(id, gameDto);
            if (game == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gameService.DeleteGameAsync(id);
            if(result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
