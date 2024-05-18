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
            throw new Exception("Name author is invalid!");
        }
    }
}
