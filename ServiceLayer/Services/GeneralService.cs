using ProductAPI.DatabaseLayer.Repositories;
using ProductAPI.Entities;
using ProductAPI.ServiceLayer.IServices;

namespace ProductAPI.ServiceLayer.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly CarRepository _carRepository;
        public GeneralService(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public string SaveCar(Car car)
        {
            _carRepository.SaveCar(car);

            return "Saved Car";
        }


        public List<Car> GetCars()
        {
            return _carRepository.GetCars();
        }
    }
}
