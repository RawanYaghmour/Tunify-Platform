using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Task<AccountDto> RegisterUser(RegisterDto registerDto);

        public Task<AccountDto> UserAuthentication(string username, string password);

        public Task<AccountDto> LogOutAsync(string username);
    }
}
