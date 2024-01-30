using DestinyHaven.Entity;
using DestinyHaven.ViewModels;

namespace DestinyHaven.Services.Interface
{
    public interface IBookingService
    {
        public Task<Booking> NewBooking(BookingViewModel bookingViewModel);
    }
}
