using HolaMundoAPI.Data.Models;

namespace HolaMundoAPI.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }
}
