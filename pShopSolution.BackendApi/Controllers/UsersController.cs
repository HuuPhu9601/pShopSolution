using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pShopSolution.Application.Comon.System.Users;
using pShopSolution.ViewModels.System.Users;

namespace pShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        [HttpPost("authenticate")]
        //chua dang nhap cx co the goi api
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tokenResult =await _usersService.Authencate(request);
            if (string.IsNullOrEmpty(tokenResult))
                return BadRequest("Username or password is incorrecet.");
            return Ok(tokenResult);
        }

        [HttpPost("register")]
        //chua dang nhap cx co the goi api
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _usersService.Register(request);
            if (!Result)
                return BadRequest("Register is unsuccessfull.");

            return Ok();
        }
    }
}
