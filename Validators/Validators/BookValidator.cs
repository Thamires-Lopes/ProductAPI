using Entities.DTOs;
using Validators.CustomExceptions;

namespace Validators.Validators
{
    public static class BookValidator
    {
        public static void ValidateBook(BookDTO book)
        {
            var exceptions = new List<BookFieldException>();

            ValidateAuthorsName(book, exceptions);
            ValidateReleaseDate(book, exceptions);

            if (exceptions.Count > 0)
            {
                throw new BookFieldsException(exceptions);
            }
        }

        #region Private methods

        private static void ValidateAuthorsName(BookDTO book, List<BookFieldException> exceptions)
        {
            if (string.IsNullOrEmpty(book.Author))
            {
                exceptions.Add(new BookFieldException("Name author is invalid!"));
            }
        }

        private static void ValidateReleaseDate(BookDTO book, List<BookFieldException> exceptions)
        {
            if (!book.ReleaseDate.HasValue)
            {
                exceptions.Add(new BookFieldException("Release date is invalid!"));
            }
        }

        #endregion
    }
}
