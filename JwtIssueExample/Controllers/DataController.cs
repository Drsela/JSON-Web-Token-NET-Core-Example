using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtIssueExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtIssueExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetData()
        {
            try
            {
                var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                var text = $"Hello from DataController. This endpoint doesn't require and token. Your role is {role ?? "not set"}.";
                return Ok(text);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AuthorizeRoles(UserType.Regular, UserType.Admin, UserType.SuperUser)]
        [HttpGet]
        [Route("user")]
        public IActionResult GetUserData()
        {
            try
            {
                var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                var text = $"Hello from DataController. All users with a valid token can access this endpoint. Your role is {role}.";
                return Ok(text);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AuthorizeRoles(UserType.Admin, UserType.SuperUser)]
        [HttpGet]
        [Route("admin")]
        public IActionResult GetAdminData()
        {
            try
            {
                var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                var text = $"Hello from DataController. Only users above admin can access this endpoint. Your role is {role}.";
                return Ok(text);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AuthorizeRoles(UserType.SuperUser)]
        [HttpGet]
        [Route("superuser")]
        public IActionResult GetSuperUserData()
        {
            try
            {
                var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                var text = $"Hello from DataController. Only superusers can access this endpoint. Your role is {role}.";
                return Ok(text);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
