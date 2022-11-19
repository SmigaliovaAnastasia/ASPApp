using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination.PagedRequests;
using ASPApp.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genreService.GetAllGenresAsync());
        }

        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _genreService.GetGenreAsync(id));
        }
    }
}
