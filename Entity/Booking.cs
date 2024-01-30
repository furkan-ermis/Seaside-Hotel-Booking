namespace DestinyHaven.Entity
{
    public class Booking
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser{ get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public string? Message { get; set; }
        public List<RoomDetail>? RoomDetails { get; set; }
    }
}
