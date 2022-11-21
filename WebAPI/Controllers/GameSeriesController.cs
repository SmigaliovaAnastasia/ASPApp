using ASPApp.Bll.Interfaces;
using ASPApp.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSeriesController : ControllerBase
    {
        private readonly IGameSeriesService _gameSeriesService;
        public GameSeriesController(IGameSeriesService gameSeriesService)
        {
            _gameSeriesService = gameSeriesService;
        }

        [HttpGet]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get()
        {
            return Ok(await _gameSeriesService.GetAllGameSeriesAsync());
        }

        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _gameSeriesService.GetGameSeriesAsync(id));
        }
    }
}
