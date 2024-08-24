using Tunify_Platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountService : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityAccountService(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = manager;
            _signInManager = signInManager;
        }

        // register
        public async Task<AccountDto> RegisterUser(RegisterDto registerDto)
        {
            var user = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }
            return null;
        }

        // login
        public async Task<AccountDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            return null;
        }

        // logout
        public async Task<AccountDto> LogOut(string username)
        {
            var logoutAccount = await _userManager.FindByNameAsync(username);
            if (logoutAccount == null)
            {
                // Handle user not found case
                return null;
            }

            // Clear the authentication cookie or token here
            await _signInManager.SignOutAsync();

            var result = new AccountDto()
            {
                Id = logoutAccount.Id,
                Username = logoutAccount.UserName
            };

            return result;
        }
    }
}
