using DestinyHaven.Entity;

namespace DestinyHaven.Services.Interface
{
    public interface IUserService
    {
        Task<AppUser> GetUserAsync(string username);
        Task<AppUser> GetUserAsync(int id);
        Task<List<AppUser>> GetAllUserAsync();
        Task<AppUser> GetUserAsync(string username, string password);
        Task<AppUser> CreateUserAsync(AppUser user);
        Task<AppUser> UpdateUserAsync(AppUser user);
        Task DeleteUserAsync(AppUser user);
    }
}
