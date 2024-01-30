using System.ComponentModel.DataAnnotations.Schema;

namespace DestinyHaven.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomSize { get; set; }
        public string Capacity { get; set; }
        public double Price { get; set; }
        public string Overview { get; set; }
        public int RoomLeft{ get; set; }
        [NotMapped]
        public List<Gallery> Images { get; set; }
        [NotMapped]
        public List<RoomFacility> RoomFacilities { get; set; }

    }
}
