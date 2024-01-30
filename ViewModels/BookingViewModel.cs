using DestinyHaven.Entity;

namespace DestinyHaven.ViewModels
{
    public class BookingViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Adult { get; set; }
        public string UserId { get; set; }
        public int Child { get; set; }
        public string? Message { get; set; }
        public List<int>? roomList { get; set; }
    }
}
