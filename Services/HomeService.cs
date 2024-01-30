using DestinyHaven.Data;
using DestinyHaven.Entity;
using DestinyHaven.Services.Interface;
using DestinyHaven.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DestinyHaven.Services
{
    public class HomeService : IHomeService
    {
        Context context=new Context();

        public async Task<bool> AddContact(Contact contact)
        {
            await context.Contacts.AddAsync(contact);
            context.SaveChanges();
            return true;
        }

        public Task<List<Facility>> GetFacilities()
        {
            var facilities = context.Facilities.ToList();
            return Task.FromResult(facilities);
        }

        public Task<List<Gallery>> GetGallery()
        {
            var gallery = context.Galleries.Where(x=>x.ImageType=="gallery").ToList();
            return Task.FromResult(gallery);
        }

        public Task<List<TestimonyViewModel>> GetTestimonials()
        {
            var testimonies = context.Testimonials
                .Include(x => x.AppUser)
                .Select(testimony => new TestimonyViewModel
                {
                    Username = testimony.AppUser.UserName,
                    Message = testimony.Message,
                })
                .ToList(); return Task.FromResult(testimonies);
        }
    }
}
