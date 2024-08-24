using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;


namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class logInController : ControllerBase
    {
        private readonly IAccountRepository _accountService;

        public logInController(IAccountRepository accountService)
        {
            _accountService = accountService;
        }
        // register
        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterDto registerDto)
        {
            var user = await _accountService.RegisterUser(registerDto);
            return Ok(user);
        }


        // login 
        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
        {
            var user = await _accountService.UserAuthentication(loginDto.UserName, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        // logout
        [HttpPost("Logout")]
        public async Task<ActionResult<AccountDto>> LogOutAsync(string username)
        {
            var newLogout = await _accountService.LogOutAsync(username);
            return newLogout;
        }
    }
}
