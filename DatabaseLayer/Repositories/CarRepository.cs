using ProductAPI.DatabaseLayer.IRepositories;
using ProductAPI.Entities;

namespace ProductAPI.DatabaseLayer.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly APIContext _apiContext;

        public CarRepository(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public void SaveCar(Car car)
        {
            _apiContext.Add(car);
            _apiContext.SaveChanges();
        }

        public List<Car> GetCars()
        {
            var cars = _apiContext.Cars.ToList();

            return cars;
        }

    }
}
