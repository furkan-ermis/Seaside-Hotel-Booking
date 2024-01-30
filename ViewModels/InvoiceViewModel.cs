using DestinyHaven.Entity;

namespace DestinyHaven.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public double Price { get; set; } // PaidPrice // Price
        public int BookingId { get; set; }// BasketId // BasketItems
        public int AppUserId { get; set; } // Buyer // UserAdress // BillingAddress
        public AppUser AppUser { get; set; }

    }
}
