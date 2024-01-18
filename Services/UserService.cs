using DestinyHaven.Data;
using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;

namespace DestinyHaven.Services
{
    public class UserService : IUserService
    {
        Context _context=new Context();
        public Task<List<AppUser>> GetAllUserAsync()
        {
            var users = _context.Users.ToList();
            var roles = _context.Roles.ToList();
            var userRole = _context.UserRoles.ToList();
            foreach (var user in users)
            {
                var roleId = userRole.FirstOrDefault(x => x.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(x => x.Id == roleId).Name;
            }
            return Task.FromResult(users);
        }
        public Task<AppUser> CreateUserAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUserAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> GetUserAsync(string username)
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> GetUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
        public Task<AppUser> UpdateUserAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
