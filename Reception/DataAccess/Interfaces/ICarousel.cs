using System.Collections.Generic;

using Model.Entities;



namespace DataAccess.Interfaces
{
    public interface ICarousel
    {
        List<Carousel> GetAllSlider();
        List<Carousel> GetAllSliderForIndex();
        void AddSlider(Carousel carousel);
        void UpdateSlider(Carousel carousel);
        void DeleteSlider(Carousel carousel);
        Carousel GetSliderById(int id);
        bool SliderExists(int id);
        Carousel GetFirstSlider();
        int SliderCount();

    }
}
