using Entities.DTOs;
using Validators.CustomExceptions;

namespace Validators.Validators
{
    public static class BookValidator
    {
        public static void ValidateBook(BookDTO book)
        {
            if (string.IsNullOrEmpty(book.Author))
            {
                throw new BookFieldException("Name author is invalid!");
            }
            else if (!book.ReleaseDate.HasValue)
            {
                throw new BookFieldException("Release date is invalid!");
            }
        }
    }
}
