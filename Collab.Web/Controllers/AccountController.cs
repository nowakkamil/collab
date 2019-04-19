using System;
using System.Threading.Tasks;
using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Collab.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _mapper;

        public AccountController(IApplicationUserService applicationUserService, IMapper mapper)
        {
            _applicationUserService = applicationUserService ??
                throw new ArgumentNullException(nameof(applicationUserService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody]ApplicationUserDto applicationUserDto)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDto);

            var identityResult = await _applicationUserService
                .CreateApplicationUserAsync(applicationUser, applicationUserDto.Password);

            if (!identityResult.Succeeded)
            {
                return BadRequest();
            }

            applicationUserDto = _mapper.Map<ApplicationUserDto>(applicationUser);
            return StatusCode(StatusCodes.Status201Created, applicationUserDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var applicationUser = await _applicationUserService.GetApplicationUserByIdAsync(id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            var applicationUserDto = _mapper.Map<ApplicationUserDto>(applicationUser);
            return Ok(applicationUserDto);
        }
    }
}
