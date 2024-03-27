using ProductAPI.Entities;

namespace ProductAPI.ServiceLayer.IServices
{
    public interface IGeneralService
    {
        string SaveCar(Car car);
        List<Car> GetCars();
    }
}
