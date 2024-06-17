using Entities.DTOs;
using Entities.Entities;

namespace Services.IServices
{
    public interface IGeneralService
    {
        string SaveCar(Car car);
        List<Car> GetCars();
        string SaveBook(BookDTO book);
        List<Book> GetBooks();
        string UpdateBook(BookDTO bookDto);
    }
}
