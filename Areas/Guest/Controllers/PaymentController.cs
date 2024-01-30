using DestinyHaven.Data;
using DestinyHaven.Entity;
using DestinyHaven.GenericModels;
using DestinyHaven.Services;
using DestinyHaven.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DestinyHaven.Areas.Guest.Controllers
{
    public class PaymentController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly Context context;
        public PaymentController(IConfiguration configuration, Context context)
        {
            _configuration = configuration;
            this.context = context;
              

        }
        public IActionResult Order()
        {
            
            Options options = new Options(); // Iyzico Import
            options.ApiKey = "sandbox-EUT8m7fcFbtmpwfilTf3qXp3Yszoc8gB";
            options.SecretKey = "BRdS4hyGTpkRIw0Qj4g76cn3vGxs8DH8";
            options.BaseUrl = "Https://sandbox-api.iyzipay.com";

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = OrderStatic.RoomDetails.Sum(x => x.Price * x.Quantity).ToString("F2", CultureInfo.InvariantCulture);
            request.PaidPrice = OrderStatic.RoomDetails.Sum(x => x.Price * x.Quantity).ToString("F2", CultureInfo.InvariantCulture);
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://localhost:7044/Guest/Payment/Approved";

            Buyer buyer = new Buyer();
            buyer.Id = "asdadsada";
            buyer.Name = "Furkan";
            buyer.Surname = "Ermis";
            buyer.GsmNumber = "+905554443322";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2000-12-12 12:00:00";
            buyer.RegistrationAddress = "Teknopark İstanbul Pendik / İstanbul ";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Furkan Ermis";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Architecht";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Erhan Kaya";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Architecht c7";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var item in OrderStatic.RoomDetails)
            {
                BasketItem basketProduct;
                basketProduct = new BasketItem();
                basketProduct.Id = "1";
                basketProduct.Name = "Room";
                basketProduct.Category1 = "Room Kategoryi";
                basketProduct.Category2 = "";
                basketProduct.ItemType = BasketItemType.PHYSICAL.ToString();

                basketProduct.Price = (item.Price*item.Quantity).ToString().Replace(",",".");
                basketItems.Add(basketProduct);
            }
           
            request.BasketItems = basketItems;
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.pay = checkoutFormInitialize.CheckoutFormContent;
            return View();
        }
        public IActionResult Approved()
        { 

            string message2= "\n\nMusteri Adi:" + OrderStatic.UserName + "\n";
            foreach (var item in OrderStatic.RoomDetails)
            {
                message2+= " \nOda No: "+item.RoomId+"\nOda Sayisi: "+item.Quantity+"\nFiyat: "+item.Price*item.Quantity+"\n";
            }
            message2+= "\n\nToplam Fiyat: " + OrderStatic.RoomDetails.Sum(x => x.Price * x.Quantity);
            string message = "Rezervasyon Numaraniz:" + OrderStatic.BookingId + message2;
            new SendMail(_configuration, OrderStatic.Email, "Admin", "User", "SeaSide Hotel Icin Rezervasyonunuz Basarili bir sekilde olusturulmustur", message);
            
            return View();
        }
    }
}
