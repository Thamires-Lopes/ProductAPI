using Entities.Entities;

namespace Repositories.IRepositories
{
    public interface IBookRepository
    {
        void SaveBook(Book book);
        List<Book> GetBooks();
    }
}
