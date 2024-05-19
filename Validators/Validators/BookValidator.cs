using Entities.DTOs;
using Validators.CustomExceptions;

namespace Validators.Validators
{
    public static class BookValidator
    {
        public static void ValidateBook(BookDTO book)
        {
            var exceptions = new List<BookFieldException>();

            if (string.IsNullOrEmpty(book.Author))
            {
                exceptions.Add(new BookFieldException("Name author is invalid!"));
            }
            if (!book.ReleaseDate.HasValue)
            {
                exceptions.Add(new BookFieldException("Release date is invalid!"));
            }

            if (exceptions.Count > 0) 
            { 
                throw new BookFieldsException(exceptions); 
            }
        }
    }
}
