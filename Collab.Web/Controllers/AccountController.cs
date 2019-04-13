using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Collab.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;

        public AccountController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService ??
                throw new ArgumentNullException(nameof(applicationUserService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var applicationUser = await _applicationUserService.GetApplicationUserByIdAsync(id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }
    }
}