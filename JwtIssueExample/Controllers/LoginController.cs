using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JwtIssueExample.DTO;
using JwtIssueExample.Exceptions;
using JwtIssueExample.Models;
using JwtIssueExample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtIssueExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AuthenticationService _authService;

        public LoginController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(401)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            try
            {
                var jwt = await _authService.Login(user);
                return Ok(jwt);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
