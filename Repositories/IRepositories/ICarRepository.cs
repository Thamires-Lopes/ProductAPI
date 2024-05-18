using Entities.Entities;

namespace Repositories.IRepositories
{
    public interface ICarRepository
    {
        void SaveCar(Car car);
        List<Car> GetCars();
    }
}
