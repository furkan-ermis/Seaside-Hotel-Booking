namespace DestinyHaven.Entity
{
    public class RoomDetail
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}
