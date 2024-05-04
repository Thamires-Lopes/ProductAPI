using ProductAPI.Entities;

namespace ProductAPI.DatabaseLayer.IRepositories
{
    public interface ICarRepository
    {
        void SaveCar(Car car);
        List<Car> GetCars();
    }
}
