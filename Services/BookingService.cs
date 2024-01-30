using DestinyHaven.Data;
using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using DestinyHaven.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DestinyHaven.Services
{
    public class BookingService : IBookingService
    {
        Context context = new Context();
        UserManager<AppUser> userManager;

        public BookingService(UserManager<AppUser> userManager,Context context)
        {
            this.userManager = userManager;
            this.context = context;
        }
            public Task<Booking> NewBooking(BookingViewModel bookingViewModel)
        {
            List<RoomDetail> roomDetails = new List<RoomDetail>();

            foreach (var Id in bookingViewModel.roomList)
            {
                Room room = context.Rooms.Where(x => x.Id == Id).FirstOrDefault();

                int quantity = bookingViewModel.roomList.Where(x => x == Id).Count();
                RoomDetail IsExistRoom = roomDetails.Find(x => x.RoomId == Id);
                if (IsExistRoom == null)
                {
                    RoomDetail roomDetail = new RoomDetail()
                    {
                        BookingId = 0,
                        RoomId = room.Id,
                        Price = room.Price,
                        Quantity = quantity,
                        Discount = 0
                    };
                    roomDetails.Add(roomDetail);
                }
            }
            //--------------------------------
            // ! rezarvasyonda bulunan her oda için gerekli kontrolleri yapıyoruz
            foreach (var roomDetail in roomDetails)
            {
                int roomQuantity = context.Rooms.Where(x => x.Id == roomDetail.RoomId).FirstOrDefault().RoomLeft;
                int orderQuantity = roomDetail.Quantity;
                
                var RoomDetailListDb = context.RoomDetails.Include(x => x.Booking).ToList();
                foreach (var roomDetailDb in RoomDetailListDb)
                {
                    // ! Database de aynı Odaları buluyoruz
                    if (roomDetail.RoomId == roomDetailDb.RoomId)
                    {
                        DateTime dbBookCheckInDate = roomDetailDb.Booking.CheckInDate;
                        DateTime dbBookCheckOutDate = roomDetailDb.Booking.CheckOutDate;
                        // ! Database deki rezervasyonun checkin ve checkout tarihleri ile
                        // ! yeni rezervasyonun checkin ve checkout tarihleri arasında çakışma var mı diye kontrol ediyoruz
                        if (!(bookingViewModel.CheckInDate > dbBookCheckOutDate && bookingViewModel.CheckOutDate < dbBookCheckInDate))
                        {
                            // ! Çakışma varsa yeni rezervasyonun checkin ve checkout tarihlerini 1 gün arttırıyoruz
                            orderQuantity++;
                        }
                    }
                }
                if (roomQuantity>= orderQuantity)
                {
                    Booking Createdbooking = CreateBooking(bookingViewModel);
                    if (Createdbooking!=null)
                    {

                        foreach (var room in roomDetails)
                        {
                            room.BookingId = Createdbooking.Id;
                        }
                        context.RoomDetails.AddRange(roomDetails);
                        context.SaveChanges();
                        return Task.FromResult(Createdbooking);

                    }
                    return Task.FromResult(new Booking());

                }
            }
            //--------------------------------




            return Task.FromResult(new Booking());
        }

        private Booking CreateBooking(BookingViewModel bookingViewModel)
        {
            if (bookingViewModel.UserId!=null)
            {

            Booking booking = new Booking()
            {
                CheckInDate = bookingViewModel.CheckInDate,
                CheckOutDate = bookingViewModel.CheckOutDate,
                Adult = bookingViewModel.Adult,
                Child = bookingViewModel.Child,
                Message = bookingViewModel.Message,
                AppUserId = bookingViewModel.UserId

            };

            context.Bookings.AddAsync(booking);
            context.SaveChanges();

            return booking;
            }
            return null;
        }
    }
}
