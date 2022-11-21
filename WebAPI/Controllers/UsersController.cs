using ASPApp.Common.Dtos.ApplicationUserDtos;
using ASPApp.Domain.Entities.Auth;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UsersController(
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return BadRequest("User not found");
            else
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userDto = _mapper.Map<ApplicationUserDto>(user);
                return Ok(userDto);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Post(Guid id, [FromBody] ApplicationUserRegisterDto userDto)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != id.ToString())
            {
                return BadRequest("Access denied");
            }

            var userExists = await _userManager.FindByIdAsync(id.ToString());
            if (userExists == null)
                return BadRequest("User not found");

            userExists = _mapper.Map(userDto, userExists);
            var result = await _userManager.UpdateAsync(userExists);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("User updated");
        }
    }
}

