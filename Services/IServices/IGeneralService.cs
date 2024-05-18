using Entities.Entities;

namespace Services.IServices
{
    public interface IGeneralService
    {
        string SaveCar(Car car);
        List<Car> GetCars();
    }
}
