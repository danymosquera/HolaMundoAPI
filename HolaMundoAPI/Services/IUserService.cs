using HolaMundoAPI.Data.Models;

namespace HolaMundoAPI.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}
