using DestinyHaven.Entity;
using DestinyHaven.ViewModels;

namespace DestinyHaven.Services.Interface
{
    public interface IHomeService
    {
        public Task<List<Facility>> GetFacilities();
        public Task<List<Gallery>> GetGallery();
        public Task<bool> AddContact(Contact contact);
        public Task<List<TestimonyViewModel>> GetTestimonials();

       
    }
}
