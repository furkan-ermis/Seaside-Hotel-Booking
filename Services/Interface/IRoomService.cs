using DestinyHaven.Entity;

namespace DestinyHaven.Services.Interface
{
    public interface IRoomService
    {
        public Task<List<Room>> GetRooms();
        public Task<Room> GetRoomById(int id);
    }
}
