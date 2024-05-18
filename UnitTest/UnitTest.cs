using Entities.DTOs;
using Validators.CustomExceptions;
using Validators.Validators;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateBookAuthorName_Invalid()
        {
            var book = new BookDTO { ReleaseDate = DateTime.Now.Date };

            var exception = Assert.Throws<BookFieldException>(() => BookValidator.ValidateBook(book));

            Assert.That(string.Equals("Name author is invalid!", exception.Message));
        }

        [Test]
        public void ValidateBookReleaseDate_Invalid()
        {
            var book = new BookDTO { Author = "Author" };

            var exception = Assert.Throws<BookFieldException>(() => BookValidator.ValidateBook(book));

            Assert.That(string.Equals("Release date is invalid!", exception.Message));
        }

        [Test]
        public void ValidateBook_Valid()
        {
            var book = new BookDTO { Author = "Author", ReleaseDate = DateTime.Now.Date };

            Assert.DoesNotThrow(() => BookValidator.ValidateBook(book));
        }
    }
}