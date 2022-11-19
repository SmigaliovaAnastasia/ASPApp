using ASPApp.Bll.Interfaces;
using ASPApp.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexityLevelsController : ControllerBase
    {
        private readonly IComplexityLevelService _complexityLevelService;
        public ComplexityLevelsController(IComplexityLevelService complexityLevelService)
        {
            _complexityLevelService = complexityLevelService;
        }

        [HttpGet]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get()
        {
            return Ok(await _complexityLevelService.GetAllComplexityLevelsAsync());
        }

        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _complexityLevelService.GetComplexityLevelAsync(id));
        }
    }
}
