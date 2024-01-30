using DestinyHaven.Entity;

namespace DestinyHaven.Services.Interface
{
    public interface IUserService
    {
        Task<List<AppUser>> GetAllUserAsync();
    }
}
