using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Data.Context;
using Model.Entities;


namespace DataAccess.Services
{
    public class CarouselService : ICarousel
    {
        private DataContext _context;

        public CarouselService(DataContext context)
        {
            _context = context;
        }

        public List<Carousel> GetAllSlider()
        {
            return _context.Carousels.ToList();
        }

        public List<Carousel> GetAllSliderForIndex()
        {
            return _context.Carousels.Skip(1).ToList();
        }

        public void AddSlider(Carousel carousel)
        {
            _context.Carousels.Add(carousel);
            _context.SaveChanges();
        }

        public void UpdateSlider(Carousel carousel)
        {
            _context.Carousels.Update(carousel);
            _context.SaveChanges();
        }

        public void DeleteSlider(Carousel carousel)
        {
            _context.Carousels.Remove(carousel);
            _context.SaveChanges();
        }

        public Carousel GetSliderById(int id)
        {
            var slider = _context.Carousels.FirstOrDefault(s => s.Id == id);
            return slider;
        }

        public bool SliderExists(int id)
        {
            return _context.Carousels.Any(s => s.Id == id);
        }

        public Carousel GetFirstSlider()
        {
            return _context.Carousels.FirstOrDefault();
        }

        public int SliderCount()
        {
            return _context.Carousels.Count();
        }
    }
}
