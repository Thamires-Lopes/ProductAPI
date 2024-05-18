using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Validators
{
    public static class BookValidator
    {
        public static void ValidateBook(BookDTO book)
        {
            if (string.IsNullOrEmpty(book.Author))
            {
                throw new Exception("Name author is invalid!");
            }
            else if (!book.ReleaseDate.HasValue)
            {
                throw new Exception("Release date is invalid!");
            }
        }
    }
}
