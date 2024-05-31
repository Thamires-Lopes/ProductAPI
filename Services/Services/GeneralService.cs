using Entities.Entities;
using Services.IServices;
using Repositories.IRepositories;
using Validators.Validators;
using Entities.DTOs;

namespace Services.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly ICarRepository _carRepository;
        private readonly IBookRepository _bookRepository;
        public GeneralService(ICarRepository carRepository, IBookRepository bookRepository)
        {
            _carRepository = carRepository;
            _bookRepository = bookRepository;
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

        public string SaveBook(BookDTO bookDto)
        {
            BookValidator.ValidateBook(bookDto);

            var book = new Book
            {
                Author = bookDto.Author,
                ReleaseDate = bookDto.ReleaseDate.Value,
                Name = bookDto.Name,
                Price = bookDto.Price
            };

            _bookRepository.SaveBook(book);

            return "Saved Book";
        }


        public List<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }
    }
}
