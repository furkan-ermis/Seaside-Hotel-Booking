using DestinyHaven.Data;
using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DestinyHaven.Services
{
    public class RoomService : IRoomService
    {
        Context context=new Context();
        public Task<List<Room>> GetRooms() 
        {
            var RoomList = context.Rooms;
            if (RoomList == null)
            {
                return null;
            }
            RoomList.ToList().ForEach(x =>
            {
                x.Images = context.Galleries.Where(y => y.ImageType == "room" && x.Id==y.TypeId).ToList();
                x.RoomFacilities = context.RoomFacilities.Where(y => y.RoomId == x.Id).ToList();
            });
            return Task.FromResult(RoomList.ToList());
        }

        public Task<Room> GetRoomById(int id)
        {
            var Room = context.Rooms.Find(id) ;
            if (Room == null)
            {
                return null;
            }
            Room.Images = context.Galleries.Where(y => y.ImageType == "room-single" && Room.Id == y.TypeId).ToList();
            Room.RoomFacilities = context.RoomFacilities.Include(x=>x.Facility).Where(y => y.RoomId == Room.Id).ToList();
            return Task.FromResult(Room);
        }
    }
}
