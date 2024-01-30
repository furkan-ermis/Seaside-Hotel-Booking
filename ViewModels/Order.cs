using DestinyHaven.Entity;
using System.Collections.Generic;

namespace DestinyHaven.ViewModels
{
    public static class OrderStatic
    {
        public static List<RoomDetail> RoomDetails { get; set; } 
        public static string UserName { get; set; }
        public static string Surname { get; set; }
        public static string BookingId { get; set; }
        public static string UserId { get; set; }
        public static string Email { get; set; }

    }
}

